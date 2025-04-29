using DZCP.MapCreator.Events.Handlers;
using PluginAPI.Events;

namespace DZCP.MapCreator
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Threading;
    using System.Threading.Tasks;
    using Exiled.API.Features;
    using HarmonyLib;
    using Map = Exiled.Events.Handlers.Map;
    using Player = Exiled.Events.Handlers.Player;
    using Server = Exiled.Events.Handlers.Server;
    using Warhead = Exiled.Events.Handlers.Warhead;

    public class DZCPMapCreator : Plugin<Config>
    {
        private Harmony _harmony;
        private FileSystemWatcher _fileWatcher;
        private Thread _dzcpThread;

        public static DZCPMapCreator Instance { get; private set; }

        public static string PluginDirectory => Path.Combine(Paths.Configs, "DZCPMapCreator");
        public static string MapsDirectory => Path.Combine(PluginDirectory, "Maps");
        public static string SchematicsDirectory => Path.Combine(PluginDirectory, "Schematics");

        public override string Name => "DZCP Map Creator";
        public override string Author => "MONCEF50G";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        public override void OnEnabled()
        {
            Instance = this;

            // إنشاء المجلدات إذا لم تكن موجودة
            Directory.CreateDirectory(PluginDirectory);
            Directory.CreateDirectory(MapsDirectory);
            Directory.CreateDirectory(SchematicsDirectory);

            // استخراج السكيمات تلقائيا من ملفات .zip
            foreach (string path in Directory.GetFiles(SchematicsDirectory))
            {
                if (path.EndsWith(".zip") && Config.AutoExtractSchematics)
                {
                    Task.Run(() =>
                    {
                        string name = Path.GetFileNameWithoutExtension(path);
                        string targetPath = Path.Combine(SchematicsDirectory, name);

                        if (Directory.Exists(targetPath))
                            Directory.Delete(targetPath, true);

                        ZipFile.ExtractToDirectory(path, targetPath);
                        Log.Info($"Extracted schematic: {name}");
                        File.Delete(path);
                    });
                }
            }

            RegisterEvents();
            PatchHarmony();

            if (Config.EnableFileWatcher)
            {
                _fileWatcher = new FileSystemWatcher(MapsDirectory, "*.yml")
                {
                    NotifyFilter = NotifyFilters.LastWrite,
                    EnableRaisingEvents = true
                };
                _fileWatcher.Changed += InternalEventHandler.OnFileChanged;
            }

            if (Config.EnableTracking)
            {
                _dzcpThread = new Thread(TrackingHandler.Loop)
                {
                    Name = "DZCP Tracker",
                    IsBackground = true
                };
                _dzcpThread.Start();
            }

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _harmony?.UnpatchAll();
            _fileWatcher?.Dispose();
            _dzcpThread?.Abort();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Map.Generated+=Events.Handlers.InternalEventHandler.OnMapGenerated();
            Server.WaitingForPlayers += InternalEventHandler.OnWaitingForPlayers;
            Server.RoundStarted += InternalEventHandler.OnRoundStarted;
            Warhead.Detonated += InternalEventHandler.OnWarheadDetonated;

            Player.Spawning += InternalEventHandler.OnPlayerSpawning;
            Player.PickingUpItem += InternalEventHandler.OnPickingUpItem;
            // أضف باقي الأحداث حسب الحاجة
        }

        private void UnregisterEvents()
        {
            Server.WaitingForPlayers -= InternalEventHandler.OnWaitingForPlayers;
            Server.RoundStarted -= InternalEventHandler.OnRoundStarted;
            Warhead.Detonated -= InternalEventHandler.OnWarheadDetonated;

            Player.Spawning -= InternalEventHandler.OnPlayerSpawning;
            Player.PickingUpItem -= InternalEventHandler.OnPickingUpItem;
            // أزل نفس الأحداث التي أضفتها
        }

        private void PatchHarmony()
        {
            _harmony = new Harmony($"dzcp.mapcreator.{DateTime.Now.Ticks}");
            _harmony.PatchAll();
        }
    }
}

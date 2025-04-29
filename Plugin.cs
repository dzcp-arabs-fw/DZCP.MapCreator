using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using DZCP.MapCreator.Managers;

namespace DZCP.MapCreator
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "DZCP.MapCreator";
        public override string Author => "MONCEF50G";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            MapManager.Initialize();
            Log.Info($"[DZCP] Map Creator v{Version} Enabled Now.");
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Log.Info("[DZCP] Map Creator Disabled.");
        }

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.InteractingDoor += PlayerHandler.OnDoorInteract;
            Exiled.Events.Handlers.Server.RoundStarted += ServerHandler.OnRoundStart;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.InteractingDoor -= PlayerHandler.OnDoorInteract;
            Exiled.Events.Handlers.Server.RoundStarted -= ServerHandler.OnRoundStart;
        }
    }
}
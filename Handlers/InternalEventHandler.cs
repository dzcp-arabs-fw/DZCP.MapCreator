using Exiled.Events.Features;
using PluginAPI.Events;

namespace DZCP.MapCreator.Events.Handlers
{
    using System;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;
    using Exiled.Events.EventArgs.Server;
    using Exiled.Events.EventArgs.Map;
    using Exiled.Events.EventArgs.Warhead;
    using System.IO;

    public static class InternalEventHandler
    {
        public static void OnWaitingForPlayers()
        {
            Log.Info("[DZCPMapCreator] السيرفر ينتظر اللاعبين...");
        }

        public static void OnRoundStarted()
        {
            Log.Info("[DZCPMapCreator] الجولة بدأت.");
        }

        public static void OnMapGenerated(MapGeneratedEvent ev)
        {
            Log.Info($"[DZCPMapCreator] تم توليد الخريطة: {Round.IsStarted}");
        }

        public static void OnWarheadDetonated()
        {
            Log.Warn("[DZCPMapCreator] انفجار النووي! سيتم إعادة تحميل السكيمات إذا لزم.");
        }

        public static void OnPlayerSpawning(SpawningEventArgs ev)
        {
            Log.Debug($"[DZCPMapCreator] اللاعب {ev.Player.Nickname} يتجسد كـ {ev.NewRole}");
        }

        public static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            Log.Debug($"[DZCPMapCreator] اللاعب {ev.Player.Nickname} يلتقط عنصر: {ev.Pickup.Type}");
        }

        public static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Log.Info($"[DZCPMapCreator] تم تعديل الملف: {e.Name}");
            // أضف إعادة تحميل الخريطة من الملف أو تطبيق التغييرات
        }

        public static CustomEventHandler OnMapGenerated()
        {
            throw new AggregateException();
        }
    }
}
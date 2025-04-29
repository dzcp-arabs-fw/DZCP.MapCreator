namespace DZCP.MapCreator.Events.Handlers
{
    using System;
    using System.Threading;
    using Exiled.API.Features;

    public static class TrackingHandler
    {
        public static void Loop()
        {
            while (DZCPMapCreator.Instance != null && DZCPMapCreator.Instance.Config.EnableTracking)
            {
                try
                {
                    Log.Debug($"[DZCP TRACKING] Players: {Player.List.Count}, Round: {(Round.IsStarted ? "Started" : "Not Started")}");
                }
                catch (Exception ex)
                {
                    Log.Error($"[DZCP TRACKING ERROR] {ex}");
                }

                Thread.Sleep(10000); // كل 10 ثواني
            }
        }
    }
}
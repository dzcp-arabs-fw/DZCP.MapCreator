using DZCP.MapCreator.Managers;
using Exiled.API.Features;

public static class ServerHandler
{
    public static void OnRoundStart()
    {
        Log.Info("[DZCP] يتم تحميل الخريطة المحفوظة...");
        MapManager.Load("DefaultMap");
    }
}
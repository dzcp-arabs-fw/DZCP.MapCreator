using DZCP.MapCreator.Managers;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

public static class PlayerHandler
{
    public static void OnDoorInteract(InteractingDoorEventArgs ev)
    {
        var pos = ev.Door.Position;
        Log.Debug($"[DZCP] تفاعل مع باب في الموقع: {pos}");
        MapManager.AddObject("Door", pos);
    }
}
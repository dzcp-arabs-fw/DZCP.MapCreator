using Exiled.API.Features.Doors;

namespace DZCP.MapCreator.API.Extensions
{
    public static class DoorExtensions
    {
        public static void ToggleLock(this Door door, bool locked)
        {
            if (locked)
                door.IsOpen = true;
        }
    
    public static void ToggleOpen(this Door door)
    {
        if (door.IsOpen)
        {
            var doorIsLocked = door.IsLocked;
        }
        else
            door.IsOpen = !door.IsOpen;
    }
}
}

using Exiled.API.Features.Lockers;

namespace DZCP.MapCreator.API.Extensions
{
    public static class LockerExtensions
    {
        public static void UnlockAll(this Locker locker)
        {
            foreach (var chamber in locker.Chambers)
                chamber.IsOpen = false;
        }
    }
}
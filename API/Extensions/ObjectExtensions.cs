using UnityEngine;

namespace DZCP.MapCreator.API.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsWithinBounds(this GameObject obj, Bounds bounds)
        {
            return bounds.Contains(obj.transform.position);
        }
    }
}
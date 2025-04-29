using UnityEngine;

namespace DZCP.MapCreator.API.Extensions
{
    public static class CullingExtensions
    {
        public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
        
    }
}
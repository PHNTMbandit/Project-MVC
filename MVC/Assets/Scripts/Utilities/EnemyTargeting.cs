using MVC.Capabilities;
using UnityEngine;

namespace MVC.Utilities
{
    public static class EnemyTargeting
    {
        public static Targetable GetClosetTargetableToCentre(Transform origin, Renderer[] renderers, float minDistance, Camera camera)
        {
            Targetable target = null;
            Vector3 currentPos = origin.position;

            foreach (var renderer in renderers)
            {
                if (IsVisible(renderer, camera))
                {
                    float distance = Vector3.Distance(renderer.transform.position, currentPos);
                    if (distance < minDistance)
                    {
                        target = renderer.GetComponent<Targetable>();
                        minDistance = distance;
                    }
                }
            }
            return target;
        }

        private static bool IsVisible(Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

            if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
                return true;
            else
                return false;
        }
    }
}

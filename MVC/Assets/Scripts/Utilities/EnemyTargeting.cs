using MVC.Capabilities;
using UnityEngine;

namespace MVC.Utilities
{
    public static class EnemyTargeting
    {
        public static Targetable GetClosetTargetableToCentre(Transform origin, Renderer[] renderers, float minDistance, Camera camera)
        {
            foreach (var renderer in renderers)
            {
                if (IsVisible(renderer, camera))
                {
                    Targetable tMin = null;
                    Vector3 currentPosition = origin.position;
                    float distance = Vector3.Distance(renderer.gameObject.transform.position, currentPosition);

                    if (distance < minDistance)
                    {
                        tMin = renderer.GetComponent<Targetable>();
                        minDistance = distance;
                    }

                    return tMin;
                }
            }

            return null;
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

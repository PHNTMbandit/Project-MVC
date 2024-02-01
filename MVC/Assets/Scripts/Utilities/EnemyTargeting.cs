using MVC.Capabilities;
using UnityEngine;

namespace MVC.Utilities
{
    public static class EnemyTargeting
    {
        public static Targetable GetClosetTargetableToCentre(Transform origin, Targetable[] targetables, float minDistance, Camera camera)
        {
            Targetable closetTarget = null;
            Vector3 currentPos = origin.position;

            foreach (var target in targetables)
            {
                if (target.IsVisible())
                {
                    float distance = Vector3.Distance(target.transform.position, currentPos);
                    if (distance < minDistance)
                    {
                        closetTarget = target.GetComponent<Targetable>();
                        minDistance = distance;
                    }
                }
            }
            return closetTarget;
        }
    }
}

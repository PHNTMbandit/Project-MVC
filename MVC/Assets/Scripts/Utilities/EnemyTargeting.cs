using MVC.Capabilities;
using UnityEngine;

namespace MVC.Utilities
{
    public static class EnemyTargeting
    {
        public static Targetable GetClosetTargetableToCentre(Transform origin, Targetable[] targetables, float minDistance)
        {
            Targetable closetTarget = null;
            Vector3 currentPos = origin.position;

            foreach (var target in targetables)
            {
                if (target.IsVisible())
                {
                    if (target.isActiveAndEnabled)
                    {
                        float distance = Vector3.Distance(target.transform.position, currentPos);
                        if (distance < minDistance)
                        {
                            closetTarget = target;
                            minDistance = distance;
                        }
                    }
                }
            }
            return closetTarget;
        }
    }
}

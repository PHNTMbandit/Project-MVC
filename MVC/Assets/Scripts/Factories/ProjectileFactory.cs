using MVC.Capabilities;
using MVC.Controllers;
using MVC.Projectiles;
using UnityEngine;

namespace MVC.Factories
{
    public class ProjectileFactory
    {
        public Projectile GetProjectile(Projectile projectilePrefab, Transform origin, Targetable target)
        {
            Projectile projectile = ObjectPoolController.Instance.GetPooledObject(projectilePrefab.name, origin.position, Quaternion.identity, null).GetComponent<Projectile>();
            projectile.Launch(origin);

            if (target != null && projectile.TryGetComponent(out Seekable seekable))
            {
                seekable.SetTarget(target);
            }

            return projectile;
        }
    }
}
using MVC.Capabilities;
using MVC.Controllers;
using MVC.Projectiles;
using UnityEngine;

namespace MVC.Factories
{
    public class ProjectileFactory
    {
        public Projectile GetProjectile(Projectile projectilePrefab, Transform origin)
        {
            Projectile projectile = ObjectPoolController.Instance.GetPooledObject(projectilePrefab.name, origin.position, Quaternion.identity, null).GetComponent<Projectile>();
            projectile.Launch(origin);

            return projectile;
        }

        public Projectile GetSeekableProjectile(Seekable seekableProjectilePrefab, Transform origin, Transform target)
        {
            Projectile projectile = ObjectPoolController.Instance.GetPooledObject(seekableProjectilePrefab.name, origin.position, Quaternion.identity, null).GetComponent<Projectile>();
            projectile.Launch(origin);
            projectile.GetComponent<Seekable>().SetTarget(target);

            return projectile;
        }
    }
}
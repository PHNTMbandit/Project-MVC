using MVC.Capabilities;
using MVC.Factories;
using MVC.Projectiles;
using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Animator))]
    [AddComponentMenu("Player/Player Shoot")]
    public class PlayerShoot : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField, Range(0, 10)]
        private float _fireRate;

        [BoxGroup("Settings"), SerializeField, Range(0, 100)]
        private float _targetingRange;

        [BoxGroup("Projectiles"), SerializeField]
        private Projectile _projectile;

        [BoxGroup("Projectiles"), SerializeField]
        private Seekable _seekableProjectile;

        [FoldoutGroup("References"), SerializeField]
        private Transform _lookingAim, _shootingOrigin;

        [FoldoutGroup("References"), SerializeField]
        private Seekable _bulletPrefab;

        public MeshRenderer[] targets;

        private Camera _camera;
        private float _nextFireTime = 0f;
        private readonly ProjectileFactory _projectileFactory = new();

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void ShootProjectile()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _fireRate;

                _projectileFactory.GetProjectile(_projectile, _shootingOrigin);
            }
        }

        public void ShootSeekable()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _fireRate;

                Targetable target = EnemyTargeting.GetClosetTargetableToCentre(transform, targets, _targetingRange, _camera);

                if (target != null)
                {
                    _projectileFactory.GetSeekableProjectile(_seekableProjectile, _shootingOrigin, target.transform);
                }
            }
        }
    }
}
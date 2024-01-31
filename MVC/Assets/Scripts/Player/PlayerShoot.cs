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
        [BoxGroup("Settings"), SerializeField]
        private Projectile _projectile;

        [FoldoutGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        [FoldoutGroup("References"), SerializeField]
        private Transform _lookingAim, _shootingOrigin;

        public MeshRenderer[] targets;

        private Camera _camera;
        private CharacterData _characterData;
        private float _nextFireTime = 0f;
        private readonly ProjectileFactory _projectileFactory = new();

        private void Awake()
        {
            _camera = Camera.main;
            _characterData = _characterDataController.GetCharacterData(name);
        }

        public void Shoot()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _characterData.fireRate;

                Targetable target = EnemyTargeting.GetClosetTargetableToCentre(transform, targets, _characterData.targetingRange, _camera);
                _projectileFactory.GetProjectile(_projectile, _shootingOrigin, target);
            }
        }
    }
}
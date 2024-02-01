using System.Linq;
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

        public Targetable[] targets;

        private Camera _camera;
        private CharacterData _characterData;
        private Targetable _currentTarget;
        private float _nextFireTime = 0f;
        private readonly ProjectileFactory _projectileFactory = new();

        private void Awake()
        {
            _camera = Camera.main;
            _characterData = _characterDataController.GetCharacterData(name);
        }

        private void Update()
        {
            _currentTarget = EnemyTargeting.GetClosetTargetableToCentre(transform, targets, _characterData.targetingRange, _camera);

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].SetCurrentTarget(_currentTarget == targets[i]);
            }
        }

        public void Shoot()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _characterData.fireRate;

                _projectileFactory.GetProjectile(_projectile, _shootingOrigin, _currentTarget);
            }
        }
    }
}
using MVC.Capabilities;
using MVC.Controllers;
using MVC.Factories;
using MVC.Projectiles;
using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Character
{
    [AddComponentMenu("Character/Character Shoot")]
    public class CharacterShoot : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField]
        private Projectile _projectile;

        [FoldoutGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        [FoldoutGroup("References"), SerializeField]
        private Transform _shootingOrigin;

        private CharacterData _characterData;
        private float _nextFireTime = 0f;
        private readonly ProjectileFactory _projectileFactory = new();

        private void Awake()
        {
            _characterData = _characterDataController.GetCharacterData(name);
        }

        public void Shoot()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _characterData.fireRate;

                _projectileFactory.GetProjectile(_projectile, _shootingOrigin, GameController.Instance.GetClosestTarget());
            }
        }

        public void Shoot(Targetable target)
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + 1f / _characterData.fireRate;

                _projectileFactory.GetProjectile(_projectile, _shootingOrigin, target);
            }
        }
    }
}
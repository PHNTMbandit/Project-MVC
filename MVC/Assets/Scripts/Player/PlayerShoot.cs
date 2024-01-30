using MVC.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [AddComponentMenu("Player/Player Shoot")]
    public class PlayerShoot : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField, Range(0, 100)]
        private float _velocity;

        [BoxGroup("References"), SerializeField]
        private Transform _shootingOrigin;

        [BoxGroup("References"), SerializeField]
        private GameObject _bulletPrefab;

        private readonly ProjectileFactory _projectileFactory = new();

        public void Shoot()
        {
            _projectileFactory.GetProjectile(_bulletPrefab, _shootingOrigin, _velocity);
        }
    }
}
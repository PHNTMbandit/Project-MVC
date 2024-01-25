using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [AddComponentMenu("Player/Player Shoot")]
    public class PlayerShoot : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private Transform _aimingTarget;

        [BoxGroup("References"), SerializeField]
        private GameObject _bulletPrefab;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Aim()
        {
            _aimingTarget.localEulerAngles = new(0, _camera.transform.localEulerAngles.y, 0);
        }

        public void Shoot()
        {
            print("shooting");
        }
    }
}
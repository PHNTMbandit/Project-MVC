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
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Aim()
        {
            float angle = Mathf.SmoothDampAngle(_aimingTarget.eulerAngles.y, _camera.transform.eulerAngles.y, ref _turnSmoothVelocity, 0.1f);
            _aimingTarget.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void Shoot()
        {
            print("shooting");
        }
    }
}
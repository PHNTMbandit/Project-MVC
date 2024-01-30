using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace MVC.Player
{
    public class PlayerAim : MonoBehaviour
    {
        [FoldoutGroup("References"), SerializeField]
        private Transform _lookingTarget, _aimingTarget;

        [FoldoutGroup("References"), SerializeField]
        private MultiAimConstraint _aimConstraint;

        private Camera _camera;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Aim()
        {
            float angleX = Mathf.SmoothDampAngle(_aimingTarget.eulerAngles.x, _camera.transform.eulerAngles.x, ref _turnSmoothVelocity, 0.1f);
            float angleY = Mathf.SmoothDampAngle(_aimingTarget.eulerAngles.y, _camera.transform.eulerAngles.y, ref _turnSmoothVelocity, 0.1f);
            _aimingTarget.rotation = Quaternion.Euler(angleX, angleY, 0);
        }

        public void Look()
        {
            Vector3 direction = (_lookingTarget.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(direction, transform.forward);

            _aimConstraint.weight = dot * 2;
        }
    }
}
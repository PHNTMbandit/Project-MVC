using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace MVC.Player
{
    public class PlayerAim : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 1), SerializeField]
        private float _aimSnap;

        [FoldoutGroup("References"), SerializeField]
        private CinemachineVirtualCamera _aimCamera;

        [FoldoutGroup("References"), SerializeField]
        private Transform _lookingTarget;

        [FoldoutGroup("References"), SerializeField]
        private MultiAimConstraint _aimConstraint;

        private float _turnSmoothVelocity;

        public void LockOn(Transform target)
        {
            _aimCamera.LookAt = target;
            Vector3 direction = (target.position - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + target.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _aimSnap);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void Look()
        {
            Vector3 direction = (_lookingTarget.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(direction, transform.forward);
            _aimConstraint.weight = dot * 2;
        }
    }
}
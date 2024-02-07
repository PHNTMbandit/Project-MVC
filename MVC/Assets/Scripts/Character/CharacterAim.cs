using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace MVC.Character
{
    [AddComponentMenu("Character/Character Aim")]
    public class CharacterAim : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 500), SerializeField]
        private float _aimSnap;

        [FoldoutGroup("References"), SerializeField]
        private CinemachineVirtualCamera _aimCamera;

        [FoldoutGroup("References"), SerializeField]
        private Transform _lookingTarget;

        [FoldoutGroup("References"), SerializeField]
        private MultiAimConstraint _aimConstraint;

        public void LockOnAim(Transform target)
        {
            _aimCamera.LookAt = target;
            Vector3 direction = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _aimSnap);
        }

        public void Look()
        {
            Vector3 direction = (_lookingTarget.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(direction, transform.forward);
            _aimConstraint.weight = dot * 2;
        }
    }
}
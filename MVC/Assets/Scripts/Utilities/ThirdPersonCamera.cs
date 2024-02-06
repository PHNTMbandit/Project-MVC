using System;
using MVC.Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Utilities
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _lookSpeed;

        [BoxGroup("Settings"), SerializeField]
        private Vector3 _followTargetOffset;

        [FoldoutGroup("References"), SerializeField]
        private Transform _followTarget, _player;

        [FoldoutGroup("References"), SerializeField]
        private InputReader _inputReader;

        public void LockOn(Transform target)
        {
            _followTarget.position = _player.position + _followTargetOffset;

            Vector3 targetDir = target.position - _followTarget.position;
            _followTarget.rotation = Quaternion.RotateTowards(_followTarget.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * 100);
        }

        public void FreeLook()
        {
            _followTarget.position = _player.position + _followTargetOffset;

            _followTarget.rotation *= Quaternion.AngleAxis(_inputReader.LookInput.x * _lookSpeed, Vector3.up);
            _followTarget.rotation *= Quaternion.AngleAxis(_inputReader.LookInput.y * _lookSpeed, Vector3.left);

            Vector3 angles = _followTarget.localEulerAngles;
            angles.z = 0;
            float angle = _followTarget.transform.localEulerAngles.x;

            if (angle > 180 && angle < 340)
            {
                angles.x = 340;
            }
            else if (angle < 180 && angle > 40)
            {
                angles.x = 40;
            }

            _followTarget.localEulerAngles = angles;
        }
    }
}
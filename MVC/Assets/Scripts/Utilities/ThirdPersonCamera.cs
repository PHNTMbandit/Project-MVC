using System;
using MVC.Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Utilities
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _rotateSpeed;

        [FoldoutGroup("References"), SerializeField]
        private Transform _followTarget;

        [FoldoutGroup("References"), SerializeField]
        private InputReader _inputReader;

        private void Update()
        {
            _followTarget.rotation *= Quaternion.AngleAxis(_inputReader.LookInput.x * _rotateSpeed, Vector3.up);
            _followTarget.rotation *= Quaternion.AngleAxis(_inputReader.LookInput.y * _rotateSpeed, Vector3.left);

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
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
            float rotationAmount = _inputReader.LookInput.x * _rotateSpeed;
            _followTarget.Rotate(Vector3.up, rotationAmount);
        }
    }
}
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMove : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField, Range(0, 100)]
        private float _moveSpeed;

        [BoxGroup("Turn"), Range(0, 1), SerializeField]
        private float _turnSmooth;

        [FoldoutGroup("References"), SerializeField]
        private Transform _followTarget, _moveTarget;

        private Animator _animator;
        private Rigidbody _rb;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>();
        }

        public void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _followTarget.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_moveTarget.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmooth);
            _moveTarget.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rb.AddForce(_moveSpeed * input.magnitude * moveDirection, ForceMode.Force);

            _animator.SetFloat("speed", _rb.velocity.magnitude);
        }
    }
}

using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMove : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 1), SerializeField]
        private float _turnSmooth;

        [FoldoutGroup("References"), SerializeField]
        private Animator _animator;

        [FoldoutGroup("References"), SerializeField]
        private Transform _followTarget;

        private Rigidbody _rb;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _rb = GetComponentInParent<Rigidbody>();
        }

        private void Update()
        {
            _animator.SetFloat("speed", Mathf.Clamp(_rb.velocity.magnitude, 0.01f, 100));
        }

        public void LockOnMove(Vector2 input, float moveSpeed)
        {
            Vector3 direction = transform.forward * input.y + transform.right * input.x;
            _rb.AddForce(direction * moveSpeed, ForceMode.Force);
        }

        public void Move(Vector2 input, float moveSpeed)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _followTarget.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rb.AddForce(moveSpeed * input.magnitude * moveDirection, ForceMode.Force);
        }

        public void Turn(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _followTarget.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}

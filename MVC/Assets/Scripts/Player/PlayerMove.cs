using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMove : MonoBehaviour
    {
        [field: BoxGroup("Settings"), SerializeField, Range(0, 100)]
        public float MoveSpeed { get; private set; }

        [BoxGroup("Turn"), Range(0, 1), SerializeField]
        private float _turnSmooth;

        [FoldoutGroup("References"), SerializeField]
        private Transform _followTarget;

        private Animator _animator;
        private Rigidbody _rb;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _rb = GetComponentInParent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat("speed", Mathf.Clamp(_rb.velocity.magnitude, 0.01f, 100));
        }

        public void Move(Vector2 input, float moveSpeed)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _followTarget.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rb.AddForce(moveSpeed * input.magnitude * moveDirection, ForceMode.Force);
        }
    }
}

using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Character
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Character/Character Movement")]
    public class CharacterMove : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 1), SerializeField]
        private float _turnSmooth;

        [FoldoutGroup("References"), SerializeField]
        private Animator _animator;

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

        public bool IsMoving()
        {
            return _rb.velocity != Vector3.zero;
        }

        public void Move(Transform target, float moveSpeed)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            _rb.AddForce(direction * moveSpeed, ForceMode.Force);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _turnSmooth * 500);
        }

        public void Move(Transform target, Vector3 direction, float moveSpeed, float damper)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + target.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rb.AddForce(moveSpeed * damper * moveDirection, ForceMode.Force);
        }

        public void LockOnMove(Vector2 input, float moveSpeed)
        {
            Vector3 direction = transform.forward * input.y + transform.right * input.x;
            _rb.AddForce(direction * moveSpeed, ForceMode.Force);
        }
    }
}

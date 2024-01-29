using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Jump")]
    public class PlayerJump : MonoBehaviour
    {
        [BoxGroup("Jump"), Range(0, 50), SerializeField]
        private float _jumpForce, _gravityScale;

        [BoxGroup("Ground Check"), Range(0, 10), SerializeField]
        private float _groundCheckDistance;

        [BoxGroup("Ground Check"), SerializeField]
        private LayerMask _groundLayers;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            SetGravityScale();
        }

        public void Jump()
        {
            _rb.AddForce(_rb.transform.up * _jumpForce, ForceMode.Impulse);
        }

        public void SetGravityScale()
        {
            Vector3 gravity = -9.81f * _gravityScale * Vector3.up;
            _rb.AddForce(gravity, ForceMode.Acceleration);
        }

        public bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayers);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _groundCheckDistance);
        }
    }
}

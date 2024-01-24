using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Jump")]
    public class PlayerJump : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 50), SerializeField]
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

        public bool IsGrounded() => Physics.Raycast(_rb.position, Vector3.down, _groundCheckDistance, _groundLayers);

        public void Jump()
        {
            if (IsGrounded())
            {
                _rb.AddForce(_rb.transform.up * _jumpForce, ForceMode.Impulse);
            }
        }

        public void FasterFall()
        {
            if (_rb.velocity.y < 0)
            {
                _rb.AddForce(-_gravityScale * Vector3.up, ForceMode.Acceleration);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _groundCheckDistance);
        }
    }
}

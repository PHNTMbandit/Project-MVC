using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Jump")]
    public class PlayerJump : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _jumpForce;

        [BoxGroup("Ground Check"), Range(0, 10), SerializeField]
        private float _groundCheckDistance;

        [BoxGroup("Ground Check"), SerializeField]
        private LayerMask _groundLayers;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayers);
        }

        public void Jump()
        {
            if (IsGrounded())
            {
                _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _groundCheckDistance);
        }
    }
}

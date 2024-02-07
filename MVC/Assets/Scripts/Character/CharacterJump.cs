using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Character
{
    [AddComponentMenu("Character/Character Jump")]
    public class CharacterJump : MonoBehaviour
    {
        [BoxGroup("Jump"), Range(0, 50), SerializeField]
        private float _gravityScale;

        [BoxGroup("Ground Check"), Range(0, 10), SerializeField]
        private float _groundCheckDistance;

        [BoxGroup("Ground Check"), SerializeField]
        private LayerMask _groundLayers;

        [FoldoutGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        private Rigidbody _rb;
        private CharacterData _characterData;

        private void Awake()
        {
            _rb = GetComponentInParent<Rigidbody>();
            _characterData = _characterDataController.GetCharacterData(name);
        }

        private void FixedUpdate()
        {
            SetGravityScale();
        }

        public void Jump()
        {
            _rb.AddForce(_rb.transform.up * _characterData.jumpForce, ForceMode.Impulse);
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

using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMovement : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private float _moveSpeed, _rotationSpeed;

        private Rigidbody _rb;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Look(Vector2 input, Transform cameraTransform)
        {
            Vector3 moveDirection = _rb.position - new Vector3(cameraTransform.position.x, _rb.position.y, cameraTransform.position.z);
            Vector3 inputDirection = _rb.transform.forward * input.y + _rb.transform.right * input.x;

            if (inputDirection != Vector3.zero)
            {
                _rb.transform.forward = Vector3.Slerp(_rb.transform.forward, input.normalized, Time.deltaTime * _rotationSpeed);
            }
        }

        public void Move(Vector2 input)
        {
            _moveDirection = transform.forward * input.y + transform.right * input.x;
            _rb.AddForce(_moveSpeed * _moveDirection.normalized, ForceMode.Force);

            Vector3 flatVelocity = new(_rb.velocity.x, 0, _rb.velocity.z);

            if (flatVelocity.magnitude > _moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * _moveSpeed;
                _rb.velocity = new(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
            }
        }
    }
}

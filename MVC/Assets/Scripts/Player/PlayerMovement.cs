using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMovement : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private float _moveSpeed;

        private Camera _camera;
        private Rigidbody _rb;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _camera = Camera.main;
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0, _camera.transform.localEulerAngles.y, 0);
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

using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Player/Player Movement")]
    public class PlayerMovement : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private float _moveSpeed, _turnSmooth;

        private Camera _camera;
        private Rigidbody _rb;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _camera = Camera.main;
            _rb = GetComponent<Rigidbody>();
        }

        public void Look()
        {
            _rb.MoveRotation(Quaternion.Euler(0, _camera.transform.localEulerAngles.y, 0));
            // transform.localRotation = Quaternion.LookRotation(_camera.transform.forward, _camera.transform.up);
        }

        public void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_rb.transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmooth);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            _rb.AddForce(_moveSpeed * moveDirection, ForceMode.Force);

            Vector3 flatVelocity = new(_rb.velocity.x, 0, _rb.velocity.z);
            if (flatVelocity.magnitude > _moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * _moveSpeed;
                _rb.velocity = new(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
            }
        }
    }
}

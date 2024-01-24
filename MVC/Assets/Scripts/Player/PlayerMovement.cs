using Cinemachine;
using MVC.Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [CreateAssetMenu(fileName = "Player Movement", menuName = "MVC/Player/Movement")]
    public class PlayerMovement : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _moveSpeed;

        [FoldoutGroup("References"), SerializeField]
        private InputReader _inputReader;

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

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            _moveDirection = transform.forward * _inputReader.MoveInput.y + transform.right * _inputReader.MoveInput.x;
            _rb.AddForce(_moveSpeed * 10f * _moveDirection.normalized, ForceMode.Force);

            Vector3 flatVelocity = new(_rb.velocity.x, 0, _rb.velocity.z);

            if (flatVelocity.magnitude > _moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * _moveSpeed;
                _rb.velocity = new(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
            }
        }
    }
}

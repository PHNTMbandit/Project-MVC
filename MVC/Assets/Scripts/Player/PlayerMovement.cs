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

        public void Move()
        {
            //    _moveDirection = transform
        }
    }
}

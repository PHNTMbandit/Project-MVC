using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Capabilities/Seekable")]
    public class Seekable : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 1000), SerializeField]
        private float _speed;

        private Rigidbody _rb;
        private Transform _target;
        private bool _isFollowing = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            _isFollowing = false;
            _target = null;
        }

        private void Update()
        {
            if (_isFollowing)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
                _rb.MovePosition(transform.position + _speed * Time.deltaTime * direction);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _isFollowing = true;
        }
    }
}
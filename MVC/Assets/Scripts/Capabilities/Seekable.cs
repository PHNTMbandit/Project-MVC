using MVC.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Capabilities/Seekable")]
    public class Seekable : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private float _speed;

        private Rigidbody _rb;
        private Targetable _target;
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

        private void FixedUpdate()
        {
            if (_isFollowing)
            {
                if (_target != null)
                {
                    if (!_target.isActiveAndEnabled)
                    {
                        gameObject.SetActive(false);
                        transform.SetParent(ObjectPoolController.Instance.transform);
                    }
                    else
                    {
                        Vector3 direction = (_target.transform.position - transform.position).normalized;
                        _rb.AddForce((direction * _speed) - _rb.velocity, ForceMode.Force);
                    }

                }
            }
        }

        public void SetTarget(Targetable target)
        {
            _target = target;
            _isFollowing = true;
        }
    }
}
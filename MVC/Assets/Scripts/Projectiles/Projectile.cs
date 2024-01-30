using MVC.Capabilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ObjectPooledObject))]
    public class Projectile : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField, Range(0, 100)]
        private float _velocity;

        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private int _damage;

        private Rigidbody _rb;
        private ObjectPooledObject _pooledObject;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _pooledObject = GetComponent<ObjectPooledObject>();
        }

        public void Launch(Transform origin)
        {
            _rb.AddForce(origin.forward * _velocity, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Damageable damageable))
            {
                damageable.Damage(_damage);

                _pooledObject.Disable();
            }
        }
    }
}
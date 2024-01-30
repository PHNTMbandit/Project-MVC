using MVC.Capabilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Projectiles
{
    [RequireComponent(typeof(ObjectPooledObject))]
    public class Projectile : MonoBehaviour
    {
        [BoxGroup("Damage"), Range(0, 100), SerializeField]
        private int _damage;

        private ObjectPooledObject _pooledObject;

        private void Awake()
        {
            _pooledObject = GetComponent<ObjectPooledObject>();
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
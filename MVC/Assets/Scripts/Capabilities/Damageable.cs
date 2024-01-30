using MVC.Data;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(Health))]
    [AddComponentMenu("Capabilities/Damageable")]
    public class Damageable : MonoBehaviour
    {
        private Health _health;

        public UnityEvent onDamaged;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void Damage(float damage)
        {
            if (_health.CurrentHealth > 0)
            {
                onDamaged?.Invoke();
            }

            _health.ChangeHealth(-damage);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}

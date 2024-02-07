using MVC.Capabilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Character
{
    [AddComponentMenu("Character/Character Melee")]
    public class CharacterMelee : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _meleeRange;

        [BoxGroup("Settings"), Range(0, 100), SerializeField]
        private float _damage;

        [BoxGroup("Settings"), SerializeField]
        private LayerMask _targetingLayers;

        public bool IsInRange() => Physics.Raycast(transform.position, transform.forward, _meleeRange, _targetingLayers);

        public void Attack()
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _meleeRange, _targetingLayers);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out Damageable damageable))
                {
                    damageable.Damage(_damage);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * _meleeRange);
        }
    }
}
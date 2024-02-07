using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Character
{
    [AddComponentMenu("Character/Character Melee")]
    public class CharacterMelee : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _meleeRange;

        [BoxGroup("Settings"), SerializeField]
        private LayerMask _targetingLayers;

        public bool IsInRange() => Physics.Raycast(transform.position, transform.forward, _meleeRange, _targetingLayers);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * _meleeRange);
        }
    }
}
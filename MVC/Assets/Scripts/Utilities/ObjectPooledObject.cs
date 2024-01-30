using MVC.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Projectiles
{
    public class ObjectPooledObject : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _lifetime;

        [FoldoutGroup("References"), SerializeField]
        private Rigidbody _rb;

        private void OnEnable()
        {
            Invoke(nameof(Disable), _lifetime);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void Disable()
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            transform.SetParent(ObjectPoolController.Instance.transform);
            gameObject.SetActive(false);
        }
    }
}
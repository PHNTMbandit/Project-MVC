using MVC.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Projectiles
{
    public class ObjectPooledObject : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 100), SuffixLabel("seconds"), SerializeField]
        private float _lifetime;

        [SerializeField]
        private UnityEvent _onDisabled;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            Invoke(nameof(Disable), _lifetime);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        public void Disable()
        {
            if (_rb != null)
            {
                _rb.velocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
            }

            transform.SetParent(ObjectPoolController.Instance.transform);
            gameObject.SetActive(false);

            _onDisabled.Invoke();
        }
    }
}
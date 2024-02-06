using MVC.Controllers;
using MVC.Data;
using MVC.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    [RequireComponent(typeof(Health))]
    [AddComponentMenu("UI/Targets/Health UI Target")]
    public class HealthUITarget : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField]
        private Vector3 _offset;

        [BoxGroup("References"), SerializeField]
        private HealthBar _healthBarPrefab;

        private Canvas _HUD;
        private Health _target;
        private HealthBar _healthBar;
        private readonly WorldUIFactory _worldUIFactory = new();

        private void Awake()
        {
            _target = GetComponent<Health>();
            _HUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        }

        private void Start()
        {
            _healthBar = _worldUIFactory.GetUI(_healthBarPrefab, transform.position, _HUD.transform, _offset);
            _healthBar.Initialise(_target);
        }

        public void RemoveUI()
        {
            _healthBar.gameObject.SetActive(false);
            _healthBar.transform.SetParent(ObjectPoolController.Instance.transform);
        }
    }
}
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
        [BoxGroup("References"), SerializeField]
        private Canvas _HUD;

        [BoxGroup("References"), SerializeField]
        private HealthBar _healthBarPrefab;

        private Health _target;
        private HealthBar _healthBarInstance;
        private readonly WorldUIFactory _worldUIFactory = new();

        private void OnDisable()
        {
            _target.onZeroHealth.RemoveListener(ResetUI);
        }

        private void Awake()
        {
            _target = GetComponent<Health>();
            _target.onZeroHealth.AddListener(ResetUI);
        }

        private void Start()
        {
            _healthBarInstance = _worldUIFactory.GetUI(_healthBarPrefab, transform.position, _HUD.transform);
            _healthBarInstance.Initialise(_target);
        }

        private void ResetUI()
        {
            _healthBarInstance.gameObject.SetActive(false);
            _healthBarInstance.transform.SetParent(ObjectPoolController.Instance.transform);
        }
    }
}
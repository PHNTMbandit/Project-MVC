using MVC.Capabilities;
using MVC.Controllers;
using MVC.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    [RequireComponent(typeof(Targetable))]
    [AddComponentMenu("UI/Targets/Auto Target UI")]
    public class AutoTargetUI : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField]
        private Vector3 _offset;

        [BoxGroup("References"), SerializeField]
        private AutoTargetIcon _targetIconPrefab;

        private Canvas _HUD;
        private Targetable _targetable;
        private AutoTargetIcon _targetIcon;
        private readonly WorldUIFactory _worldUIFactory = new();

        private void Awake()
        {
            _targetable = GetComponent<Targetable>();
            _HUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        }

        private void Update()
        {
            if (GameController.Instance.LockedOnTarget == _targetable)
            {
                _targetIcon.gameObject.SetActive(true);
                _targetIcon.SetIconAlpha(1);
            }
            else if (GameController.Instance.GetClosestTarget() == _targetable && GameController.Instance.LockedOnTarget == null)
            {
                _targetIcon.gameObject.SetActive(true);
                _targetIcon.SetIconAlpha(0.25f);
            }
            else
            {
                _targetIcon.gameObject.SetActive(false);
            }
        }

        public void Initialise(Transform target)
        {
            _targetIcon = _worldUIFactory.GetUI(_targetIconPrefab, target.transform, _HUD.transform, _offset);
            _targetIcon.SetIconAlpha(0.25f);
        }

        public void RemoveUI()
        {
            _targetIcon.gameObject.SetActive(false);
            _targetIcon.transform.SetParent(ObjectPoolController.Instance.transform);
        }
    }
}
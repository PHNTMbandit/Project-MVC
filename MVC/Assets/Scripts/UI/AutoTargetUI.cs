using MVC.Controllers;
using MVC.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    [AddComponentMenu("UI/Targets/Auto Target UI")]
    public class AutoTargetUI : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField]
        private Vector3 _offset;

        [BoxGroup("References"), SerializeField]
        private AutoTargetIcon _targetIconPrefab;

        private Canvas _HUD;
        private AutoTargetIcon _targetIcon;
        private readonly WorldUIFactory _worldUIFactory = new();

        private void Awake()
        {
            _HUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        }

        public void Initialise(Renderer target)
        {
            _targetIcon = _worldUIFactory.GetUI(_targetIconPrefab, target.bounds.center, _HUD.transform, _offset);
            _targetIcon.gameObject.SetActive(false);
        }

        public void SetAutoTargetIconEnabled(bool enable)
        {
            _targetIcon.gameObject.SetActive(enable);
        }

        public void RemoveUI()
        {
            _targetIcon.gameObject.SetActive(false);
            _targetIcon.transform.SetParent(ObjectPoolController.Instance.transform);
        }
    }
}
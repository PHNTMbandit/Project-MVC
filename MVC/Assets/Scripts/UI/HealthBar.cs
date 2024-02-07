using MVC.Data;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.UI
{
    [AddComponentMenu("UI/Bars/Health Bar")]
    public class HealthBar : MonoBehaviour
    {
        [BoxGroup("Settings"), ToggleLeft, SerializeField]
        private bool _hasInstance, _hasAmountText;

        [BoxGroup("Settings"), ShowIf("_hasInstance"), SerializeField]
        private Health _target;

        [BoxGroup("Settings"), ShowIf("_hasAmountText"), SerializeField]
        private TextMeshProUGUI _amountText;

        [BoxGroup("References"), SerializeField]
        private Slider _slider;

        private void Awake()
        {
            if (_hasInstance)
            {
                UpdateSlider();

                _target.onHealthChanged.AddListener(UpdateSlider);
            }
        }

        public void Initialise(Health target)
        {
            _target = target;

            UpdateSlider();

            _target.onHealthChanged.AddListener(UpdateSlider);
        }

        private void UpdateSlider()
        {
            _slider.maxValue = _target.MaxHealth;
            _slider.value = _target.CurrentHealth;

            if (_hasAmountText)
            {
                _amountText.SetText($"{_target.CurrentHealth}/{_target.MaxHealth}");
            }
        }
    }
}
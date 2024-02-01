using MVC.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.UI
{
    [AddComponentMenu("UI/Bars/Health Bar")]
    public class HealthBar : MonoBehaviour
    {
        public Health Target { get; private set; }

        [BoxGroup("References"), SerializeField]
        private Slider _slider;

        public void Initialise(Health target)
        {
            Target = target;

            UpdateSlider();

            Target.onHealthChanged.AddListener(UpdateSlider);
        }

        private void UpdateSlider()
        {
            _slider.maxValue = Target.MaxHealth;
            _slider.value = Target.CurrentHealth;
        }
    }
}
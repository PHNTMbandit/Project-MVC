using UnityEngine;
using UnityEngine.UI;

namespace MVC.UI
{
    public class AutoTargetIcon : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        public void SetIconAlpha(float alpha)
        {
            var tempColor = _icon.color;
            tempColor.a = alpha;
            _icon.color = tempColor;
        }
    }
}
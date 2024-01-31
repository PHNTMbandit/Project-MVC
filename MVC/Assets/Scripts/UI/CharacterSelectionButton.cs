using UnityEngine;
using UnityEngine.UI;

namespace MVC.UI
{
    public class CharacterSelectionButton : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }
    }
}
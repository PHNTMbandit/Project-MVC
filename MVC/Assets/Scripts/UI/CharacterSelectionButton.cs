using MVC.Controllers;
using MVC.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.UI
{
    public class CharacterSelectionButton : MonoBehaviour
    {
        public CharacterData Character { get; private set; }

        [SerializeField]
        private Image _icon, _border;

        [SerializeField]
        private CharacterSelectionController _characterSelectionController;

        public void SetCharacter(CharacterData character)
        {
            Character = character;
        }

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        public void SetBorderColour(Color colour)
        {
            _border.color = colour;
        }

        public void OnClick()
        {
            _characterSelectionController.SetCurrentCharacter(Character);
        }
    }
}
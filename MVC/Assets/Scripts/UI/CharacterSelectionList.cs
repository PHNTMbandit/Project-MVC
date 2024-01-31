using System.Collections.Generic;
using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    public class CharacterSelectionList : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        [BoxGroup("References"), SerializeField]
        private CharacterSelectionButton _templateSelectionButton;

        [BoxGroup("References"), SerializeField]
        private Transform _list;

        private readonly List<CharacterSelectionButton> _buttons = new();

        private void Awake()
        {
            _templateSelectionButton.gameObject.SetActive(false);
        }

        private void Start()
        {
            GenerateList();
        }

        public void GenerateList()
        {
            ResetList();

            foreach (CharacterData character in _characterDataController.CharacterListData.characters)
            {
                CharacterSelectionButton button = Instantiate(_templateSelectionButton, _list);
                button.gameObject.SetActive(true);

                button.SetIcon(Resources.Load<Sprite>(character.spritePath));

                _buttons.Add(button);
            }
        }

        private void ResetList()
        {
            if (_buttons.Count > 0)
            {
                foreach (CharacterSelectionButton button in _buttons)
                {
                    Destroy(button.gameObject);
                }

                _buttons.Clear();
            }
        }
    }
}
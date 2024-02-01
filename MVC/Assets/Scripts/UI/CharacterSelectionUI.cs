using System.Collections.Generic;
using MVC.Controllers;
using MVC.Utilities;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace MVC.UI
{
    public class CharacterSelectionUI : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField]
        private Color _defaultBorderColour, _selectedBorderColour;

        [BoxGroup("Grid"), SerializeField]
        private CharacterSelectionButton _templateSelectionButton;

        [BoxGroup("Grid"), SerializeField]
        private Transform _grid;

        [BoxGroup("3D Model"), SerializeField]
        private Transform _modelHolder;

        [BoxGroup("3D Model"), SerializeField]
        private Transform _templateModel;

        [BoxGroup("Information"), SerializeField]
        private TextMeshProUGUI _currentCharacterName, _information;

        [BoxGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        [BoxGroup("References"), SerializeField]
        private CharacterSelectionController _characterSelectionController;

        private readonly List<CharacterSelectionButton> _buttons = new();

        private void Awake()
        {
            _templateSelectionButton.gameObject.SetActive(false);
            _templateModel.gameObject.SetActive(false);

            _characterSelectionController.onCharacterChange.AddListener(UpdateUI);
        }

        private void Start()
        {
            GenerateList();
            UpdateUI();
        }

        public void GenerateList()
        {
            ResetList();

            foreach (CharacterData character in _characterDataController.CharacterListData.characters)
            {
                CharacterSelectionButton button = Instantiate(_templateSelectionButton, _grid);
                button.gameObject.SetActive(true);

                button.SetCharacter(character);
                button.SetIcon(character.sprite);

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

        private void UpdateUI()
        {
            CharacterData currentCharacter = _characterSelectionController.CurrentCharacter;
            _currentCharacterName.SetText(currentCharacter.name);
            _information.SetText($"Fire Rate: {currentCharacter.fireRate} \n Range: {currentCharacter.targetingRange} \n Speed: {currentCharacter.moveSpeed} Jump: {currentCharacter.jumpForce}");

            _buttons.Find(i => i.Character == currentCharacter)?.SetBorderColour(_selectedBorderColour);
            List<CharacterSelectionButton> unselectedCharacterButtons = _buttons.FindAll(i => i.Character != currentCharacter);

            for (int i = 0; i < unselectedCharacterButtons.Count; i++)
            {
                unselectedCharacterButtons[i].SetBorderColour(_defaultBorderColour);
            }
        }
    }
}
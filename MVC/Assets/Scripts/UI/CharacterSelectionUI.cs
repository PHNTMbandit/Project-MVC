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
        private Transform _modelHolder, _templateModel;

        [BoxGroup("Information"), SerializeField]
        private TextMeshProUGUI _currentCharacterName, _information;

        [BoxGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        [BoxGroup("References"), SerializeField]
        private CharacterSelectionController _characterSelectionController;

        private readonly List<GameObject> _models = new();
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
                button.SetIcon(Resources.Load<Sprite>($"Sprites/{character.name}"));

                _buttons.Add(button);
            }

            GenerateModels();
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

        private void GenerateModels()
        {
            CharacterData[] characters = _characterDataController.CharacterListData.characters;
            for (int i = 0; i < characters.Length; i++)
            {
                GameObject model = Instantiate(Resources.Load<GameObject>($"Meshes/UI/{characters[i].name} UI Model"), _modelHolder.transform.position, Quaternion.identity, _modelHolder);
                model.transform.SetLocalPositionAndRotation(_templateModel.localPosition, _templateModel.localRotation);
                model.SetActive(false);

                _models.Add(model);
            }
        }

        private void UpdateUI()
        {
            CharacterData currentCharacter = _characterSelectionController.CurrentCharacter;
            _currentCharacterName.SetText(currentCharacter.name);
            _information.SetText($"Fire Rate: {currentCharacter.fireRate} \n Range: {currentCharacter.targetingRange} \n Speed: {currentCharacter.moveSpeed} Jump: {currentCharacter.jumpForce}");

            _buttons.Find(i => i.Character == currentCharacter)?.SetBorderColour(_selectedBorderColour);
            List<CharacterSelectionButton> unselectedCharacterButtons = _buttons.FindAll(i => i.Character != currentCharacter);

            for (int i = 0; i < _models.Count; i++)
            {
                _models[i].transform.eulerAngles = new Vector3(0, -180, 0);
                _models[i].SetActive(_models[i].name.Split(' ')[0] == currentCharacter.name);
            }

            for (int i = 0; i < unselectedCharacterButtons.Count; i++)
            {
                unselectedCharacterButtons[i].SetBorderColour(_defaultBorderColour);
            }
        }
    }
}
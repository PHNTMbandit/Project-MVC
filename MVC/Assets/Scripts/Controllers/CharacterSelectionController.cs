using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Controllers
{
    public class CharacterSelectionController : MonoBehaviour
    {
        public CharacterData CurrentCharacter { get; private set; }

        [BoxGroup("Settings"), SerializeField]
        private GameObject _defaultStartingCharacter;

        [BoxGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        public UnityEvent onCharacterChange;

        private void Awake()
        {
            SetCurrentCharacter(_characterDataController.GetCharacterData(_defaultStartingCharacter.name));
        }

        public void SetCurrentCharacter(CharacterData data)
        {
            CurrentCharacter = data;

            onCharacterChange?.Invoke();
        }
    }
}
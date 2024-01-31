using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Utilities
{
    [Serializable]
    public class CharacterData
    {
        public string name;
        public string spritePath;
        public int spriteIndex;
    }

    [CreateAssetMenu(fileName = "Character Data", menuName = "MVC/Character Data")]
    public class CharacterDataController : ScriptableObject
    {
        [Serializable, HideLabel]
        public class CharacterList
        {
            [ReadOnly, TableList(AlwaysExpanded = true, DrawScrollView = false)]
            public CharacterData[] characters;
        }

        [SerializeField, Required]
        private TextAsset _JSONFile;

        [SerializeField]
        private CharacterList _characterList = new();

        private void OnEnable()
        {
            _characterList = JsonUtility.FromJson<CharacterList>(_JSONFile.text);
        }

        public CharacterData GetCharacterData(string name)
        {
            return Array.Find(_characterList.characters, i => i.name == name);
        }
    }
}
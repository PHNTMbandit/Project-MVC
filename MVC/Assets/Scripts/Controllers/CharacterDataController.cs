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
        public float fireRate;
        public float targetingRange;
        public float moveSpeed;
        public float jumpForce;
        public float airMoveSpeed;
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

        [ShowInInspector]
        public CharacterList CharacterListData { get; private set; } = new();

        [SerializeField, Required]
        private TextAsset _JSONFile;

        private void OnValidate()
        {
            CharacterListData = JsonUtility.FromJson<CharacterList>(_JSONFile.text);
        }

        public CharacterData GetCharacterData(string name)
        {
            return Array.Find(CharacterListData.characters, i => i.name == name);
        }
    }
}
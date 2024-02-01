using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Utilities
{
    [Serializable]
    public class CharacterData
    {
        public string name;
        public GameObject model;
        public Sprite sprite;
        public float fireRate;
        public float targetingRange;
        public float moveSpeed;
        public float jumpForce;
        public float airMoveSpeed;
    }

    [CreateAssetMenu(fileName = "Character Data", menuName = "MVC/Character Data")]
    public class CharacterDataController : ScriptableObject
    {
        [Serializable]
        public class CharacterList
        {
            [TableList(AlwaysExpanded = true, DrawScrollView = false)]
            public CharacterData[] characters;
        }

        public CharacterList CharacterListData = new();

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
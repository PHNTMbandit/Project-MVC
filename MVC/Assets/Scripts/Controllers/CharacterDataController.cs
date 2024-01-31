using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Utilities
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "MVC/Character Data")]
    public class CharacterDataController : ScriptableObject
    {
        [Serializable]
        public class CharacterData
        {
            public string name;
            public string spritePath;
            public int spriteIndex;
        }

        [Serializable, HideLabel]
        public class CharacterList
        {
            public CharacterData c_0;
            public CharacterData c_1;
            public CharacterData c_2;
            public CharacterData c_3;
            public CharacterData c_4;
            public CharacterData c_5;
            public CharacterData c_6;
            public CharacterData c_7;
            public CharacterData c_8;
            public CharacterData c_9;
            public CharacterData c_10;
            public CharacterData c_11;
        }

        [SerializeField, Required]
        private TextAsset _JSONFile;

        [SerializeField]
        private CharacterList _characterList = new();

        private void OnEnable()
        {
            _characterList = JsonUtility.FromJson<CharacterList>(_JSONFile.text);
        }
    }
}
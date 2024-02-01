using MVC.Capabilities;
using MVC.Utilities;
using UnityEngine;

namespace MVC.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Targetable[] _enemies;

        [SerializeField]
        private CharacterSelectionController _characterSelectionController;

        private Camera _camera;

        #region Singleton

        public static GameController Instance
        { get { return _instance; } }

        private static GameController _instance;

        private void Awake()
        {
            _camera = Camera.main;

            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        private void Update()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].SetCurrentTarget(GetClosestTarget() == _enemies[i]);
            }
        }

        public Targetable GetClosestTarget()
        {
            return EnemyTargeting.GetClosetTargetableToCentre(transform, _enemies, _characterSelectionController.CurrentCharacter.targetingRange, _camera);
        }
    }
}
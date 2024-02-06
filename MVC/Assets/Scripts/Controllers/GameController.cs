using MVC.Capabilities;
using MVC.Utilities;
using UnityEngine;

namespace MVC.Controllers
{
    public class GameController : MonoBehaviour
    {
        public Targetable LockedOnTarget { get; private set; }

        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private Targetable[] _enemies;

        [SerializeField]
        private CharacterSelectionController _characterSelectionController;

        #region Singleton

        public static GameController Instance
        { get { return _instance; } }

        private static GameController _instance;

        private void Awake()
        {
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

        public Targetable GetClosestTarget()
        {
            return EnemyTargeting.GetClosetTargetableToCentre(_player.transform, _enemies, _characterSelectionController.CurrentCharacter.targetingRange);
        }

        public void SetLockedOnTarget(Targetable targetable)
        {
            LockedOnTarget = targetable;
        }
    }
}
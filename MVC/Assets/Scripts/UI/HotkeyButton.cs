using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.UI
{
    public class HotkeyButton : MonoBehaviour
    {
        [SerializeField]
        private string _actionName;

        [SerializeField]
        private UnityEvent _onActionPerformed;

        private GameControls _gameControls;
        private InputAction _action;

        private void Awake()
        {
            _gameControls = new GameControls();
            _action = _gameControls.FindAction(_actionName);
            _action.performed += context => _onActionPerformed.Invoke();
        }

        private void OnEnable()
        {
            _gameControls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _gameControls.Gameplay.Disable();
        }


        private void Start()
        {
        }
    }
}
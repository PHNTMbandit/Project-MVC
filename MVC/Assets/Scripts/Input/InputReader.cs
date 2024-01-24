using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.Input
{
    [CreateAssetMenu(fileName = "Input Handler", menuName = "MVC/Input/Input Handler", order = 1)]
    public class InputReader : ScriptableObject, GameControls.IGameplayActions
    {
        public GameControls GameControls { get; private set; }
        public bool JumpInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public Vector2 MoveInput { get; private set; }

        [HideInInspector]
        public UnityEvent onJump;

        private void OnEnable()
        {
            if (GameControls == null)
            {
                GameControls = new GameControls();
                GameControls.Gameplay.AddCallbacks(this);
                GameControls.Gameplay.AddCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableGameplayInput();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                JumpInput = true;

                onJump?.Invoke();
            }
            else if (context.canceled)
            {
                JumpInput = false;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }

        public void EnableGameplayInput()
        {
            GameControls.Gameplay.Disable();
        }

        public void DisableGameplayInput()
        {
            GameControls.Gameplay.Disable();
        }
    }
}

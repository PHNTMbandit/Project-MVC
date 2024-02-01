using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.Input
{
    [CreateAssetMenu(fileName = "Input Handler", menuName = "MVC/Input/Input Handler", order = 1)]
    public class InputReader : ScriptableObject, GameControls.IGameplayActions
    {
        public GameControls GameControls { get; private set; }
        public bool AimInput { get; private set; }
        public bool ClickInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool ShootInput { get; private set; }
        public bool SprintInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public Vector2 MoveInput { get; private set; }
        public Vector2 PointerPosition { get; private set; }

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

        public void OnAim(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                AimInput = true;
            }
            else if (context.canceled)
            {
                AimInput = false;
            }
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ClickInput = true;
            }
            else if (context.canceled)
            {
                ClickInput = false;
            }
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

        public void OnOpenCharacterSelection(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
            }
        }

        public void OnPointerPosition(InputAction.CallbackContext context)
        {
            PointerPosition = context.ReadValue<Vector2>();
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ShootInput = true;
            }
            else if (context.canceled)
            {
                ShootInput = false;
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SprintInput = true;
            }
            else if (context.canceled)
            {
                SprintInput = false;
            }
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

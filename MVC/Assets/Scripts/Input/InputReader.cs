using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.Input
{
    [CreateAssetMenu(fileName = "Input Reader", menuName = "MVC/Input/Input Reader", order = 1)]
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

        public UnityAction onJump;

        private void OnEnable()
        {
            GameControls ??= new GameControls();

            EnableGameplayInput(true);
        }

        private void OnDisable()
        {
            EnableGameplayInput(false);
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

        public void EnableGameplayInput(bool enable)
        {
            if (enable)
            {
                GameControls.Gameplay.AddCallbacks(this);
                GameControls.Gameplay.Enable();
            }
            else
            {
                GameControls.Gameplay.RemoveCallbacks(this);
                GameControls.Gameplay.Disable();
            }
        }
    }
}

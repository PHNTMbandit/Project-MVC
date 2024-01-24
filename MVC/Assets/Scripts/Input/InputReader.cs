using UnityEngine;
using UnityEngine.InputSystem;

namespace MVC.Input
{
    [CreateAssetMenu(fileName = "Input Handler", menuName = "MVC/Input/Input Handler", order = 1)]
    public class InputReader : ScriptableObject, GameControls.IGameplayActions
    {
        public GameControls GameControls { get; private set; }
        public Vector2 MoveInput { get; private set; }

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

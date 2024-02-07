using UnityEngine;

namespace MVC.Controllers.StateMachine.SuperStates
{
    public class GameOverState : GameState
    {
        public GameOverState(GameStateController stateController) : base(stateController)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Cursor.visible = true;
            stateController.PlayerInput.SwitchCurrentActionMap("UI");
        }
    }
}
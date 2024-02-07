using UnityEngine;

namespace MVC.Controllers.StateMachine.SuperStates
{
    public class GameVictoryState : GameState
    {
        public GameVictoryState(GameStateController stateController) : base(stateController)
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
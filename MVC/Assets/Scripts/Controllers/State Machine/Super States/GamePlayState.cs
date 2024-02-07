using UnityEngine;

namespace MVC.Controllers.StateMachine.SuperStates
{
    public class GamePlayState : GameState
    {
        public GamePlayState(GameStateController stateController) : base(stateController)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Cursor.visible = false;
            stateController.PlayerInput.SwitchCurrentActionMap("Gameplay");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.IsMenusOpen())
            {
                stateController.StateMachine.ChangeState(stateController.MenuState);
            }

            if (GameController.Instance.Player.CurrentHealth <= 0)
            {
                stateController.StateMachine.ChangeState(stateController.GameOverState);
            }
        }
    }
}
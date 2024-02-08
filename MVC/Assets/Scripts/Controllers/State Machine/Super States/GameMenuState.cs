using UnityEngine;

namespace MVC.Controllers.StateMachine.SuperStates
{
    public class GameMenuState : GameState
    {
        public GameMenuState(GameStateController stateController) : base(stateController)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Cursor.visible = true;
            stateController.InputReader.EnableGameplayInput(false);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!stateController.IsMenusOpen())
            {
                stateController.StateMachine.ChangeState(stateController.PlayState);
            }
        }
    }
}
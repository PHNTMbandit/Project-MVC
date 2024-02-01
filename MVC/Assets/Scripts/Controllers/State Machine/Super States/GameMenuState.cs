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

            stateController.PlayerInput.SwitchCurrentActionMap("UI");
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
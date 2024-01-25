namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.InputReader.onJump.RemoveAllListeners();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerJump.FasterFall();
        }
    }
}
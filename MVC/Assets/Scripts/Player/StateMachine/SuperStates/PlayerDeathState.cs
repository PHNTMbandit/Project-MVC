namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerDeathState : PlayerState
    {
        public PlayerDeathState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
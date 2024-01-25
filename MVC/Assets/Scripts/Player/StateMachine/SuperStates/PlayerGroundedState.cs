namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.InputReader.onJump.AddListener(stateController.PlayerJump.Jump);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot();
            }
        }
    }
}
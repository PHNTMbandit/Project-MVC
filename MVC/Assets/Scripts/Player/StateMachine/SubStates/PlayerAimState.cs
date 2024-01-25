namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerAimState : PlayerGroundedState
    {
        public PlayerAimState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            if (!stateController.InputReader.AimInput)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerShoot.Aim();
        }
    }
}
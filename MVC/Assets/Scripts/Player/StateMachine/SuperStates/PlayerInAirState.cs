namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerStateController stateController) : base(stateController)
        {
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerMovement.Move(stateController.InputReader.MoveInput);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.PlayerJump.IsGrounded())
            {
                stateController.StateMachine.ChangeState(stateController.GroundedState);
            }
        }
    }
}
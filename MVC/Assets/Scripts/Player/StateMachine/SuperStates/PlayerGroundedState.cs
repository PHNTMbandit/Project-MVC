namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(PlayerStateController stateController) : base(stateController)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.InputReader.onJump += stateController.PlayerJump.Jump;
        }

        public override void OnExit()
        {
            base.OnExit();

            stateController.InputReader.onJump -= stateController.PlayerJump.Jump;
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerMovement.Move(stateController.InputReader.MoveInput);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!stateController.PlayerJump.IsGrounded())
            {
                stateController.StateMachine.ChangeState(stateController.InAirState);
            }
        }
    }
}
namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerAimState : PlayerGroundedState
    {
        public PlayerAimState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot();
            }

            if (!stateController.InputReader.AimInput)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerAim.Aim();
            stateController.PlayerMove.Move(stateController.InputReader.MoveInput, stateController.CharacterData.moveSpeed);
        }
    }
}
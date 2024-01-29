using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.AimInput)
            {
                stateController.StateMachine.ChangeState(stateController.AimState);
            }

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot();
            }

            if (!stateController.PlayerJump.IsGrounded())
            {
                stateController.StateMachine.ChangeState(stateController.InAirState);
            }
        }
    }
}
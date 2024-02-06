using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            stateController.ThirdPersonCamera.FreeLook();

            if (stateController.PlayerJump.IsGrounded())
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (stateController.InputReader.MoveInput != Vector2.zero)
            {
                stateController.PlayerMove.Move(stateController.InputReader.MoveInput, stateController.CharacterData.airMoveSpeed);
            }
        }
    }
}
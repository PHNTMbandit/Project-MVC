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
                Vector3 input = stateController.InputReader.MoveInput;
                stateController.PlayerMove.Move(stateController.FollowTarget,
                                                new Vector3(input.x, 0, input.y).normalized,
                                                stateController.CharacterData.airMoveSpeed,
                                                stateController.InputReader.MoveInput.magnitude);
            }
        }
    }
}
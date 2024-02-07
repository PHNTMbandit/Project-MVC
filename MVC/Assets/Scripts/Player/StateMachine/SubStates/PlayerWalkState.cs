using MVC.Controllers;
using UnityEngine;
using MVC.Player.StateMachine.SuperStates;

namespace MVC.Player.StateMachine.SubStates
{
    public class PlayerWalkState : PlayerGroundedState
    {
        public PlayerWalkState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.InputReader.onJump.AddListener(stateController.PlayerJump.Jump);
        }

        public override void OnExit()
        {
            base.OnExit();

            stateController.InputReader.onJump.RemoveAllListeners();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            stateController.ThirdPersonCamera.FreeLook();

            if (GameController.Instance.GetClosestTarget() != null && stateController.InputReader.AimInput)
            {
                stateController.StateMachine.ChangeState(stateController.AimState);
            }

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot();
            }

            if (stateController.InputReader.MoveInput == Vector2.zero)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            Vector3 input = stateController.InputReader.MoveInput;
            stateController.PlayerMove.Move(stateController.FollowTarget,
                                            new Vector3(input.x, 0, input.y).normalized,
                                            stateController.CharacterData.moveSpeed,
                                            stateController.InputReader.MoveInput.magnitude);
        }
    }
}
using MVC.Controllers;
using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
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

            stateController.ThirdPersonCamera.UpdateCamera();

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

            stateController.PlayerMove.Move(stateController.InputReader.MoveInput, stateController.CharacterData.moveSpeed);
            stateController.PlayerMove.Turn(stateController.InputReader.MoveInput);
        }
    }
}
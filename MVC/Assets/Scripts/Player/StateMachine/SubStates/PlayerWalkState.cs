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

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.ShootSeekable();
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
        }
    }
}
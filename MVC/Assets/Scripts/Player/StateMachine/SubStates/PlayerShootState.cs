using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerShootState : PlayerGroundedState
    {
        public PlayerShootState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            if (!stateController.InputReader.ShootInput)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerMove.Move(Vector2.zero, 0);
        }
    }
}
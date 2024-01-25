using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.MoveInput != Vector2.zero)
            {
                stateController.StateMachine.ChangeState(stateController.WalkState);
            }
        }
    }
}
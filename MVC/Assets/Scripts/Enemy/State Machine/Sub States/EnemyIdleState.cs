using MVC.Enemy.StateMachine.SuperStates;

namespace MVC.Enemy.StateMachine.SubStates
{
    public class EnemyIdleState : EnemyGroundedState
    {
        public EnemyIdleState(EnemyStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.EnemyMove.IsMoving())
            {
                stateController.StateMachine.ChangeState(stateController.MoveState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.MoveToPlayer();
        }
    }
}
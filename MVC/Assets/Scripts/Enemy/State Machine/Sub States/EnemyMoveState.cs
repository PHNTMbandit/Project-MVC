using MVC.Enemy.StateMachine.SuperStates;

namespace MVC.Enemy.StateMachine.SubStates
{
    public class EnemyMoveState : EnemyGroundedState
    {
        public EnemyMoveState(EnemyStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!stateController.EnemyMove.IsMoving())
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.MoveToPlayer();
        }
    }
}
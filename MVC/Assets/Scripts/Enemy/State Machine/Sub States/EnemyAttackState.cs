using MVC.Enemy.StateMachine.SuperStates;

namespace MVC.Enemy.StateMachine.SubStates
{
    public class EnemyAttackState : EnemyGroundedState
    {
        public EnemyAttackState(EnemyStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!stateController.EnemyMelee.IsInRange() || stateController.IsTargetDead())
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }
    }
}
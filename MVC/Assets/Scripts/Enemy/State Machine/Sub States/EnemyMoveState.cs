using MVC.Enemy.StateMachine.SuperStates;
using UnityEngine;

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

            if (stateController.EnemyMelee.IsInRange())
            {
                stateController.StateMachine.ChangeState(stateController.AttackState);
            }

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
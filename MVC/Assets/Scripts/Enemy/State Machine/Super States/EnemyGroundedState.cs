namespace MVC.Enemy.StateMachine.SuperStates
{
    public class EnemyGroundedState : EnemyState
    {
        public EnemyGroundedState(EnemyStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }
    }
}
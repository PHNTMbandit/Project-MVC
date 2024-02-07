namespace MVC.Enemy.StateMachine
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public void Initialise(EnemyState startingState)
        {
            CurrentState = startingState;
            startingState.OnEnter();
        }

        public void ChangeState(EnemyState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            newState.OnEnter();
        }
    }
}
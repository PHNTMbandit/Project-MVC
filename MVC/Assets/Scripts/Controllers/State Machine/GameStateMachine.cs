namespace MVC.Controllers.StateMachine
{
    public class GameStateMachine
    {
        public GameState CurrentState { get; private set; }

        public void Initialise(GameState startingState)
        {
            CurrentState = startingState;
            startingState.OnEnter();
        }

        public void ChangeState(GameState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            newState.OnEnter();
        }
    }
}
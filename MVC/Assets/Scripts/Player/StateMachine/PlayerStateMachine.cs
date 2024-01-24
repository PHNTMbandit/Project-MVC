using Sirenix.OdinInspector;

namespace MVC.Player.StateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }

        public void Initialise(PlayerState startingState)
        {
            CurrentState = startingState;
            startingState.OnEnter();
        }

        public void ChangeState(PlayerState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            newState.OnEnter();
        }
    }
}
namespace MVC.Controllers.StateMachine
{
    public abstract class GameState
    {
        protected GameStateController stateController;

        protected GameState(GameStateController stateController)
        {
            this.stateController = stateController;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }
    }
}
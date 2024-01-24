namespace MVC.Player.StateMachine
{
    public abstract class PlayerState
    {
        protected PlayerStateController stateController;

        protected PlayerState(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
    }

}
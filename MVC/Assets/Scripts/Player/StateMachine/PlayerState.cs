namespace MVC.Player.StateMachine
{
    public abstract class PlayerState
    {
        protected PlayerStateController stateController;
        protected string stateAnimationName;

        protected PlayerState(PlayerStateController stateController, string stateAnimationName)
        {
            this.stateController = stateController;
            this.stateAnimationName = stateAnimationName;
        }
        public virtual void OnEnter()
        {
            stateController.Animator.SetBool(stateAnimationName, true);
        }

        public virtual void OnExit()
        {
            stateController.Animator.SetBool(stateAnimationName, false);
        }

        public virtual void OnUpdate()
        {
            if (stateController.Health.CurrentHealth <= 0)
            {
                stateController.StateMachine.ChangeState(stateController.DeathState);
            }
        }

        public virtual void OnFixedUpdate()
        {
        }
    }
}
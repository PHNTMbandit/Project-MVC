namespace MVC.Enemy.StateMachine
{
    public abstract class EnemyState
    {
        protected EnemyStateController stateController;
        protected string stateAnimationName;

        protected EnemyState(EnemyStateController stateController, string stateAnimationName)
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
        }

        public virtual void OnFixedUpdate()
        {
        }
    }
}
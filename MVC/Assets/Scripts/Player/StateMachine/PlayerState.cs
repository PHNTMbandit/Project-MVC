using UnityEngine;

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

        protected PlayerState(PlayerStateController stateController)
        {
            this.stateController = stateController;
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
            stateController.PlayerMovement.Look();
        }

        public virtual void OnFixedUpdate()
        {
        }
    }
}
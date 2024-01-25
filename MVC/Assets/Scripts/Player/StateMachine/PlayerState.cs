using UnityEngine;

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

        public virtual void OnUpdate()
        {
            stateController.PlayerMovement.Look();
        }

        public virtual void OnFixedUpdate()
        {
            if (stateController.InputReader.MoveInput != Vector2.zero)
            {
                stateController.PlayerMovement.Move(stateController.InputReader.MoveInput);
            }
        }
    }
}
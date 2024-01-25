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
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate()
        {
            stateController.PlayerMovement.Move(stateController.InputReader.MoveInput);
            //   stateController.PlayerMovement.Look(stateController.InputReader.LookInput, Camera.main.transform);
        }
    }

}
using MVC.Controllers;
using UnityEngine;

namespace MVC.Player.StateMachine.SuperStates
{
    public class PlayerAimState : PlayerGroundedState
    {
        private Transform _lockOnTarget;

        public PlayerAimState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockOnTarget = GameController.Instance.GetClosestTarget().transform;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot();
            }

            if (!stateController.InputReader.AimInput || _lockOnTarget == null)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerAim.LockOn(_lockOnTarget.transform);
            stateController.PlayerMove.Move(stateController.InputReader.MoveInput, stateController.CharacterData.moveSpeed);
        }
    }
}
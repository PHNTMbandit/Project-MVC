using MVC.Capabilities;
using MVC.Controllers;
using MVC.Player.StateMachine.SuperStates;
using UnityEngine;

namespace MVC.Player.StateMachine.SubStates
{
    public class PlayerAimState : PlayerGroundedState
    {
        private Targetable _lockOnTarget;

        public PlayerAimState(PlayerStateController stateController, string stateAnimationName) : base(stateController, stateAnimationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockOnTarget = GameController.Instance.GetClosestTarget();
            GameController.Instance.SetLockedOnTarget(_lockOnTarget);
            stateController.InputReader.onJump.AddListener(stateController.PlayerJump.Jump);
        }

        public override void OnExit()
        {
            base.OnExit();

            GameController.Instance.SetLockedOnTarget(null);
            stateController.InputReader.onJump.RemoveAllListeners();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            stateController.ThirdPersonCamera.LockOn(_lockOnTarget.transform);
            stateController.Animator.SetFloat("aim move input x", Mathf.Lerp(stateController.Animator.GetFloat("aim move input x"), stateController.InputReader.MoveInput.x, 4 * Time.deltaTime));
            stateController.Animator.SetFloat("aim move input y", Mathf.Lerp(stateController.Animator.GetFloat("aim move input y"), stateController.InputReader.MoveInput.y, 4 * Time.deltaTime));

            if (stateController.InputReader.ShootInput)
            {
                stateController.PlayerShoot.Shoot(_lockOnTarget);
            }

            if (!stateController.InputReader.AimInput || !_lockOnTarget.isActiveAndEnabled)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.PlayerAim.LockOnAim(_lockOnTarget.transform);
            stateController.PlayerMove.LockOnMove(stateController.InputReader.MoveInput, stateController.CharacterData.moveSpeed);
        }
    }
}
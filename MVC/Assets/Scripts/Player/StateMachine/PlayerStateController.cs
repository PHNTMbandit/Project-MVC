using MVC.Input;
using MVC.Player.StateMachine.SuperStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player.StateMachine
{
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerMove))]
    [RequireComponent(typeof(PlayerShoot))]
    [AddComponentMenu("Player/Player State Controller")]
    public class PlayerStateController : MonoBehaviour
    {
        [field: FoldoutGroup("References"), SerializeField]
        public InputReader InputReader { get; private set; }

        public Animator Animator { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerAimState AimState { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public PlayerJump PlayerJump { get; private set; }
        public PlayerMove PlayerMove { get; private set; }
        public PlayerShoot PlayerShoot { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            AimState = new(this, "aiming");
            IdleState = new(this, "idle");
            InAirState = new(this, "jumping");
            WalkState = new(this, "walking");

            Animator = GetComponentInChildren<Animator>();
            PlayerJump = GetComponent<PlayerJump>();
            PlayerMove = GetComponent<PlayerMove>();
            PlayerShoot = GetComponent<PlayerShoot>();
        }

        private void Start()
        {
            Cursor.visible = false;

            StateMachine.Initialise(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }
    }
}
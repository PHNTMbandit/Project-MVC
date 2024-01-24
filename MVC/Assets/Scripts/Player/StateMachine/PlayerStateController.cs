using MVC.Input;
using MVC.Player.StateMachine.SuperStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player.StateMachine
{
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerShoot))]
    [AddComponentMenu("Player/Player State Controller")]
    public class PlayerStateController : MonoBehaviour
    {
        [field: FoldoutGroup("References"), SerializeField]
        public InputReader InputReader { get; private set; }

        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerGroundedState GroundedState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerJump PlayerJump { get; private set; }
        public PlayerMovement PlayerMovement { get; private set; }
        public PlayerShoot PlayerShoot { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            GroundedState = new(this);
            InAirState = new(this);

            PlayerJump = GetComponent<PlayerJump>();
            PlayerMovement = GetComponent<PlayerMovement>();
            PlayerShoot = GetComponent<PlayerShoot>();
        }

        private void Start()
        {
            Cursor.visible = false;

            StateMachine.Initialise(GroundedState);
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
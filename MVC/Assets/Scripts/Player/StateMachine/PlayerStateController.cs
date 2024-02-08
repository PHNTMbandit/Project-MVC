using MVC.Character;
using MVC.Data;
using MVC.Input;
using MVC.Player.StateMachine.SubStates;
using MVC.Player.StateMachine.SuperStates;
using MVC.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player.StateMachine
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(CharacterAim))]
    [RequireComponent(typeof(CharacterJump))]
    [RequireComponent(typeof(CharacterMove))]
    [RequireComponent(typeof(CharacterShoot))]
    [AddComponentMenu("Player/Player State Controller")]
    public class PlayerStateController : MonoBehaviour
    {
        [field: FoldoutGroup("References"), SerializeField]
        public Transform FollowTarget { get; private set; }

        [field: FoldoutGroup("References"), SerializeField]
        public Animator Animator { get; private set; }

        [field: FoldoutGroup("References"), SerializeField]
        public ThirdPersonCamera ThirdPersonCamera { get; private set; }

        [FoldoutGroup("References"), SerializeField]
        private CharacterDataController _characterDataController;

        public Health Health { get; private set; }
        public InputReader InputReader { get; private set; }
        public CharacterData CharacterData { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerAimState AimState { get; private set; }
        public PlayerDeathState DeathState { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public CharacterAim PlayerAim { get; private set; }
        public CharacterJump PlayerJump { get; private set; }
        public CharacterMove PlayerMove { get; private set; }
        public CharacterShoot PlayerShoot { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            AimState = new(this, "aiming");
            DeathState = new(this, "dead");
            IdleState = new(this, "idle");
            InAirState = new(this, "jumping");
            WalkState = new(this, "walking");

            Health = GetComponent<Health>();
            PlayerAim = GetComponent<CharacterAim>();
            PlayerJump = GetComponent<CharacterJump>();
            PlayerMove = GetComponent<CharacterMove>();
            PlayerShoot = GetComponent<CharacterShoot>();
            CharacterData = _characterDataController.GetCharacterData(name);

            InputReader = ScriptableObject.CreateInstance<InputReader>();
            InputReader.onJump += PlayerJump.Jump;
        }

        private void Start()
        {
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
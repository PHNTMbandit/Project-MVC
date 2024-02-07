using MVC.Character;
using MVC.Controllers;
using MVC.Enemy.StateMachine.SubStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Enemy.StateMachine
{
    [RequireComponent(typeof(CharacterMelee))]
    [RequireComponent(typeof(CharacterMove))]
    [AddComponentMenu("Enemy/Enemy State Controller")]
    public class EnemyStateController : MonoBehaviour
    {
        [field: BoxGroup("Settings"), Range(0, 100), SerializeField]
        public float MoveSpeed { get; private set; }

        [field: FoldoutGroup("References"), SerializeField]
        public Animator Animator { get; private set; }

        public EnemyStateMachine StateMachine { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        public EnemyIdleState IdleState { get; private set; }
        public EnemyMoveState MoveState { get; private set; }
        public CharacterMelee EnemyMelee { get; private set; }
        public CharacterMove EnemyMove { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            AttackState = new(this, "attacking");
            IdleState = new(this, "idle");
            MoveState = new(this, "walking");

            EnemyMelee = GetComponent<CharacterMelee>();
            EnemyMove = GetComponent<CharacterMove>();
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

        public void MoveToPlayer()
        {
            Transform target = GameController.Instance.Player.transform;
            EnemyMove.Move(target, MoveSpeed);
        }
    }
}
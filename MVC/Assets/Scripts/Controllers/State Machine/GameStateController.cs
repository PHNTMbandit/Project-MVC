using System.Linq;
using MVC.Controllers.StateMachine.SuperStates;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVC.Controllers.StateMachine
{
    public class GameStateController : MonoBehaviour
    {
        public GameStateMachine StateMachine { get; private set; }
        public GameOverState GameOverState { get; private set; }
        public GameMenuState MenuState { get; private set; }
        public GamePlayState PlayState { get; private set; }

        [field: SerializeField]
        public PlayerInput PlayerInput { get; private set; }

        [SerializeField]
        private UIPanel[] _UIPanels;

        private void Awake()
        {
            StateMachine = new();
            GameOverState = new(this);
            MenuState = new(this);
            PlayState = new(this);
        }

        private void Start()
        {
            StateMachine.Initialise(PlayState);
        }

        private void Update()
        {
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }

        public bool IsMenusOpen()
        {
            return _UIPanels.Any(i => i.gameObject.activeSelf);
        }
    }
}
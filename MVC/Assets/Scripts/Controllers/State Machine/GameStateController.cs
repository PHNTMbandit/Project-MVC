using System.Linq;
using MVC.Controllers.StateMachine.SuperStates;
using MVC.Input;
using UnityEngine;

namespace MVC.Controllers.StateMachine
{
    public class GameStateController : MonoBehaviour
    {
        public GameStateMachine StateMachine { get; private set; }
        public GameOverState GameOverState { get; private set; }
        public GameVictoryState VictoryState { get; private set; }
        public GameMenuState MenuState { get; private set; }
        public GamePlayState PlayState { get; private set; }
        public InputReader InputReader { get; private set; }

        [SerializeField]
        private UIPanel[] _UIPanels;

        private void Awake()
        {
            StateMachine = new();
            GameOverState = new(this);
            MenuState = new(this);
            PlayState = new(this);
            VictoryState = new(this);

            InputReader = ScriptableObject.CreateInstance<InputReader>();
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

        public void ChangeToVictoryState()
        {
            StateMachine.ChangeState(VictoryState);
        }
    }
}
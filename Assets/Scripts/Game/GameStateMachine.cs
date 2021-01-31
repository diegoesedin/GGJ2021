using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.FSM
{
    public class GameStateMachine : MonoBehaviour
    {
        public enum StateEnum
        {
            Menu,
            Game,
            Final
        }

        private State selectedState;
        private Dictionary<StateEnum, State> fsm = new Dictionary<StateEnum, State>();

        void Start()
        {
            Initialize();
        }

        void Update()
        {
            selectedState.Update();
        }

        public void Initialize()
        {
            MenuState menuState = new MenuState();
            GameState gameState = new GameState();
            FinalState finalState = new FinalState();
            
            fsm.Add(StateEnum.Menu, menuState);
            fsm.Add(StateEnum.Game, gameState);
            fsm.Add(StateEnum.Final, finalState);

            selectedState = fsm[StateEnum.Menu];
            selectedState.Init();
            selectedState.Enter();
        }

        public void ChangeState(StateEnum newState)
        {
            selectedState.Exit();

            selectedState = fsm[newState];
            selectedState.Enter();
        }

    }
}
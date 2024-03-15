using System;
using System.Collections.Generic;
using Game.GameStates;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class GameStateManager
    {
        [Inject] private WaitingForPlayState _waitingForPlayState;
        [Inject] private ReadyForPlayState _readyForPlayState;


        private Dictionary<Type, IGameState> _states;
        public Type CurrentStateType { get; private set; }


        public void Init()
        {
            _states = new Dictionary<Type, IGameState>()
            {
                { typeof(WaitingForPlayState), _waitingForPlayState },
                { typeof(ReadyForPlayState), _readyForPlayState }
            };

            _readyForPlayState.EnterState = () => { CurrentStateType = typeof(WaitingForPlayState); };
        }

        public void ToState<T>() where T : IGameState
        {
            CurrentStateType = typeof(T);
            Debug.Log("CurrentState type: " + CurrentStateType);
        }


        public void DiceClick()
        {
            _states[CurrentStateType].DiceClick();
        }
        
        
    }
}
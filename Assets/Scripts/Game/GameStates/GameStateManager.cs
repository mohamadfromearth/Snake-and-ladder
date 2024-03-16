using System;
using System.Collections.Generic;
using GameStates;
using UnityEngine;
using Zenject;

namespace Game.GameStates
{
    public class GameStateManager
    {
        [Inject] private WaitingForPlayState _waitingForPlayState;
        [Inject] private ReadyForPlayState _readyForPlayState;


        private Dictionary<Type, IGameState> _states;
        private Type _currentStateType;


        public void Init()
        {
            _states = new Dictionary<Type, IGameState>()
            {
                { typeof(WaitingForPlayState), _waitingForPlayState },
                { typeof(ReadyForPlayState), _readyForPlayState }
            };

            _readyForPlayState.EnterState = ToState<WaitingForPlayState>;
        }

        public void ToState<T>() where T : IGameState
        {
            _currentStateType = typeof(T);
            Debug.Log("CurrentState type: " + _currentStateType);
        }


        public void DiceClick()
        {
            _states[_currentStateType].DiceClick();
        }
    }
}
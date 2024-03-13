using System;
using System.Collections.Generic;
using Zenject;

namespace GameStates
{
    public class GameStateManager : IGameState
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
        }


        public void ToState<T>() where T : IGameState
        {
            _currentStateType = typeof(T);
        }

        public void DiceClick()
        {
            _states[_currentStateType].DiceClick();
        }
    }
}
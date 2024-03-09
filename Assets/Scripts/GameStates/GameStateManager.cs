using Zenject;

namespace GameStates
{
    public class GameStateManager : IGameState
    {
        [Inject] private WaitingForPlayState _waitingForPlayState;
        [Inject] private ReadyForPlayState _readyForPlayState;
        private IGameState _currentState;


        public void Init()
        {
            _currentState = _readyForPlayState;
        }

        public void DiceClick()
        {
            _currentState.DiceClick();
            _currentState = _waitingForPlayState;
        }


        public void OnPlayerMoveFinished()
        {
            _currentState = _readyForPlayState;
        }
    }
}
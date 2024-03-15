using System;

namespace GameStates
{
    public interface IGameState
    {
        public Action EnterState { get; set; }
        public Action ExitState { get; set; }
        void DiceClick();
    }
}
using System;
using GameStates;

namespace Game.GameStates
{
    public class WaitingForPlayState : IGameState
    {
        public Action EnterState { get; set; }
        public Action ExitState { get; set; }

        public void DiceClick()
        {
            return;
        }

        public void Cancel()
        {
        }
    }
}
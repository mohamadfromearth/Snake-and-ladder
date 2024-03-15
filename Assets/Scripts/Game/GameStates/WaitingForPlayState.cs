using System;

namespace GameStates
{
    public class WaitingForPlayState : IGameState
    {
        public Action EnterState { get; set; }
        public Action ExitState { get; set; }

        public void DiceClick()
        {
            return;
        }
    }
}

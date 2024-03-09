using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

namespace GameStates
{
    public class ReadyForPlayState : IGameState
    {
        [Inject] private Player _player;
        [Inject] private Dice _dice;
        [Inject] private Grid _grid;

        public void DiceClick()
        {
            var diceValue = _dice.Roll();
            Debug.Log("On Dice Click" + diceValue);
            var position = _player.transform.position;
            var nextPosition = _grid.GetNextPosition(diceValue, position);
            _player.Move(nextPosition);
        }
    }
}
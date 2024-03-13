using Event;
using Game.Objects;
using GameStates;
using Objects.Dice;
using Zenject;
using Grid = GridStructure.Grid;

namespace Game.GameStates
{
    public class ReadyForPlayState : IGameState
    {
        [Inject] private Player _player;
        [Inject] private Dice _dice;
        [Inject] private Grid _grid;
        [Inject] private DiceController _diceController;
        [Inject] private EventChannel _channel;

        public void DiceClick()
        {
            var diceValue = _dice.Roll();
            _diceController.SetImage(diceValue);
            var position = _player.transform.position;
            var nextPosition = _grid.GetNextPosition(diceValue, position);
            _player.Move(nextPosition);
        }
    }
}
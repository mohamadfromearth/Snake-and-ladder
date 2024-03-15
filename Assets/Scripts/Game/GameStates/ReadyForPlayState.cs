using System;
using System.Collections;
using DG.Tweening;
using Event;
using Event.EventsData;
using Game.Objects;
using Game.Objects.Cell;
using GameStates;
using Objects.Dice;
using UnityEngine;
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
        [Inject] private CellContainer _cellContainer;
        [Inject] private EventChannel _channel;

        public Action EnterState { get; set; }
        public Action ExitState { get; set; }

        public void DiceClick()
        {
            EnterState?.Invoke();
            var diceValue = _dice.Roll();
            _diceController.SetImage(diceValue);

            if (IsOutOfBounds(diceValue))
            {
                _channel.Rise<PlayerMoveFinishedEventData>(new PlayerMoveFinishedEventData());
                ExitState?.Invoke();
            }
            else
            {
                _player.StartCoroutine(MoveRoutine(diceValue));
            }
        }

        private bool IsOutOfBounds(int diceValue)
        {
            return _grid.GetNextPosition(diceValue, _player.transform.position) == (Vector2)_player.transform.position;
        }

        private IEnumerator MoveRoutine(int diceValue)
        {
            var position = _player.transform.position;
            for (int i = 1; i <= diceValue; i++)
            {
                var nextPosition = _grid.GetNextPosition(i, position);
                _player.Move(nextPosition);

                var nextIndices = _grid.GetIndicesByPosition(nextPosition);
                if (nextIndices.y % 2 != 0)
                {
                    nextIndices.x = _grid.Row - nextIndices.x - 1;
                }

                _cellContainer.GetCell(nextIndices).GetTransform().DOScale(1.05f, _player.MoveTime)
                    .SetLoops(2, LoopType.Yoyo);

                yield return new WaitForSeconds(_player.MoveTime);
            }

            _channel.Rise<PlayerMoveFinishedEventData>(new PlayerMoveFinishedEventData());
            ExitState?.Invoke();
        }
    }
}
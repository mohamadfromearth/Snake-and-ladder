using Cell;
using GameStates;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

public class GameManager : MonoBehaviour
{
    [Inject] private Grid _grid;
    [Inject] private CellsPlacer _cellsPlacer;
    [Inject] private GameStateManager _gameStateManager;
    [Inject] private Player _player;
    [Inject] private DiceController _diceController;


    private void Start()
    {
        _gameStateManager.Init();
        _gameStateManager.ToState<ReadyForPlayState>();
        _cellsPlacer.PlaceCells();
        _player.AddMoveFinishedListener(() => { _gameStateManager.ToState<ReadyForPlayState>(); });
        _diceController.AddClickListener(DiceClick);
    }


    private void DiceClick()
    {
        _gameStateManager.DiceClick();
        _gameStateManager.ToState<WaitingForPlayState>();
    }
}
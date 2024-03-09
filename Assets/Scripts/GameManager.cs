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


    private void Start()
    {
        _gameStateManager.Init();
        _cellsPlacer.PlaceCells();
        SetPlayerMoveFinishListener();
    }


    // events
    public void OnDiceClick()
    {
        _gameStateManager.DiceClick();
    }

    private void SetPlayerMoveFinishListener()
    {
        _player.AddMoveFinishedListener(() =>
        {
            _gameStateManager.OnPlayerMoveFinished();
        });
    }
}
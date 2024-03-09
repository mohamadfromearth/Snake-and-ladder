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


    private void Start()
    {
        _gameStateManager.Init();
        _cellsPlacer.PlaceCells();
    }


    // events
    public void OnDiceClick()
    {
        _gameStateManager.DiceClick();
    }

    private void OnPlayerMoveFinished(Vector2 position)
    {
    }
}
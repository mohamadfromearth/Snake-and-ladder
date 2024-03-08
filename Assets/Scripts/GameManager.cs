using Cell;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

public class GameManager : MonoBehaviour
{
    [Inject] private Grid _grid;
    [Inject] private CellsPlacer _cellsPlacer;
    
    private void Start()
    {
        _cellsPlacer.PlaceCells();
    }
}
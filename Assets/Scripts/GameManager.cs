using System;
using UnityEngine;
using Grid = GridStructure.Grid;

public class GameManager : MonoBehaviour
{
    private CellsPlacer _cellsPlacer;
    private Grid _grid;
    [SerializeField] private DefaultCellFactory _defaultCellFactory;


    private void Start()
    {
        Init();
        _cellsPlacer.PlaceCells();
    }


    private void Init()
    {
        _grid = new Grid(1, 6, 6);
        _cellsPlacer = new CellsPlacer(_defaultCellFactory, 6, 6);
    }
}
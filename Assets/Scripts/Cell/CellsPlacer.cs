using UnityEngine;

public class CellsPlacer
{
    

    private ICellFactory _cellFactory;
    private int _row, _column;

    public CellsPlacer(ICellFactory cellFactory, int row, int column)
    {
        _cellFactory = cellFactory;
        _row = row;
        _column = column;
    }

    public void PlaceCells()
    {
        for (int row = 0; row <= _row; row++)
        {
            for (int column = 0; column < _column; column++)
            {
                var cell = _cellFactory.Create();
                cell.SetPosition(GetPosition(row, column,cell.Size));
            }
        }
    }


    private Vector2 GetPosition(int row, int column, int cellSize)
    {
        var x = row * cellSize + cellSize / 2f;
        var y = column * cellSize + cellSize / 2f;
        return new Vector2(x, y);
    }
}
using UnityEngine;
using Zenject;

namespace Cell
{
    public class CellsPlacer : IPlacer
    {
        [Inject] private ICellFactory _cellFactory;
        private int _row, _column;

        public CellsPlacer(int row, int column)
        {
            _row = row;
            _column = column;
        }

        private Vector2 GetPosition(int row, int column, int cellSize)
        {
            var x = row * cellSize + cellSize / 2f;
            var y = column * cellSize + cellSize / 2f;
            return new Vector2(x, y);
        }

        public void Place()
        {
            for (int row = 0; row < _row; row++)
            {
                for (int column = 0; column < _column; column++)
                {
                    var cell = _cellFactory.Create();
                    cell.SetPosition(GetPosition(row, column, cell.Size));
                }
            }
        }
    }
}
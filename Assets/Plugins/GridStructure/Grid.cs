using UnityEngine;

namespace GridStructure
{
    public class Grid
    {
        // public 
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int CellSize { get; private set; }

        // local
        private Cell[,] _grid;

        public Grid(int cellSize, int row, int column)
        {
            CellSize = cellSize;
            Row = row;
            Column = column;

            Init();
        }

        // public functions
        public Vector2 GetPosition(int row, int column)
        {
            var x = row * CellSize + CellSize / 2f;
            var y = column * CellSize + CellSize / 2f;
            return new Vector2(x, y);
        }


        // local functions
        private void Init()
        {
            _grid = new Cell[Row, Column];

            for (int row = 0; row < Row; row++)
            {
                for (int column = 0; column < Column; column++)
                {
                    _grid[row, column] = new Cell(GetPosition(row, column));
                }
            }
        }
    }
}
using PlasticGui.WebApi.Responses;
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
        public virtual Vector2 GetPosition(int row, int column)
        {
            var x = row * CellSize + CellSize / 2f;
            var y = column * CellSize + CellSize / 2f;
            return new Vector2(x, y);
        }

        public virtual Vector2Int GetIndicesByPosition(Vector2 position)
        {
            var x = (int)(position.x / CellSize - CellSize / 2f);
            var y = (int)(position.y / CellSize - CellSize / 2f);
            return new Vector2Int(x, y);
        }

        public Vector2 GetNextPosition(int cellCount, Vector2 position)
        {
            var indices = GetIndicesByPosition(position);

            if (IsOutOfBounds(cellCount, indices)) return position;

            var nextIndices = GetNextIndices(indices, cellCount);
            var pos = GetPosition(nextIndices.x, nextIndices.y);
            return pos;
        }

        protected virtual bool IsOutOfBounds(int cellCount, Vector2Int indices)
        {
            return indices.y == Column - 1 && indices.x + cellCount >= Row;
        }

        public Vector2Int GetNextIndices(Vector2Int indices, int count)
        {
            int x;
            int y;
            if (indices.x + count >= Row)
            {
                x = count - (Row - indices.x);
                y = indices.y + 1;
                return new Vector2Int(x, y);
            }

            return new Vector2Int(indices.x + count, indices.y);
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
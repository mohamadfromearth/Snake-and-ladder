using UnityEngine;
using Grid = GridStructure.Grid;

namespace Plugins.GridStructure
{
    public class SnakeLadderGrid : Grid
    {
        public SnakeLadderGrid(int cellSize, int row, int column) : base(cellSize, row, column)
        {
        }


        public override Vector2 GetPosition(int row, int column)
        {
            if (column % 2 != 0)
            {
                row = Row - row - 1;
            }
            var x = row * CellSize + CellSize / 2f;
            var y = column * CellSize + CellSize / 2f;
            return new Vector2(x, y);
        }

        public override Vector2Int GetIndicesByPosition(Vector2 position)
        {
            var x = (int)(position.x / CellSize - CellSize / 2f);
            var y = (int)(position.y / CellSize - CellSize / 2f);
            if (y % 2 != 0)
            {
                x = Row - x - 1;
            }

            return new Vector2Int(x, y);
        }
    }
}
using Game.Objects.Cell;
using UnityEngine;

namespace Event.EventsData
{
    public class CellPlaced : IEventData
    {
        public CellPlaced(Vector2Int indices, ICell cell)
        {
            Indices = indices;
            Cell = cell;
        }

        public ICell Cell { get; }

        public Vector2Int Indices { get; }
    }
}
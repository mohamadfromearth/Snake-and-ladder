using System.Collections.Generic;
using Cell;
using Event;
using Event.EventsData;
using UnityEngine;
using Zenject;

namespace Game.Objects.Cell
{
    public class CellContainer
    {
        private EventChannel _channel;
        private readonly Dictionary<Vector2Int, ICell> _cellsDictionary = new Dictionary<Vector2Int, ICell>();

        [Inject]
        private void Construct(EventChannel eventChannel)
        {
            _channel = eventChannel;
            _channel.Subscribe<CellPlaced>(OnCellPlaced);
        }

        private void OnCellPlaced()
        {
            var data = _channel.GetData<CellPlaced>();
            _cellsDictionary[data.Indices] = data.Cell;
        }

        public ICell GetCell(Vector2Int indices)
        {
            return _cellsDictionary[indices];
        }
    }
}
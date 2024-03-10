using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

namespace Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        [Inject] private Grid _grid;
        private readonly ShortcutList _shortcutList;

        private readonly Dictionary<Vector2Int, ShortcutData> _shortCutListDictionary;


        public BoardRepository(ShortcutList shortcutList)
        {
            _shortcutList = shortcutList;
            _shortCutListDictionary = new Dictionary<Vector2Int, ShortcutData>();
            InitShortcutDic();
        }


        private void InitShortcutDic()
        {
            foreach (var shortcutData in _shortcutList.ShortcutDatas)
            {
                _shortCutListDictionary[shortcutData.start] = shortcutData;
            }
        }

        public ShortcutData GetShortcutByPosition(Vector3 position)
        {

            var indices = _grid.GetIndicesByPosition(position);

            if (_shortCutListDictionary.TryGetValue(indices, out var data))
            {
                return data;
            }

            return null;
        }

        public Vector3? GetShortcutPositionByPosition(Vector3 position)
        {
            var shortcut = GetShortcutByPosition(position);

            if (shortcut == null)
            {
                return null;
            }

            return _grid.GetPosition(shortcut.end.x, shortcut.end.y);
        } 

        public Vector2Int GetBoardSize()
        {
            return new Vector2Int(_grid.Row,_grid.Column);
        }

        public int GetCellSize()
        {
            return _grid.CellSize;
        }
    }
}
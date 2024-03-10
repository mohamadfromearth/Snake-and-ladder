using JetBrains.Annotations;
using UnityEngine;

namespace Data.Repositories
{
    public interface IBoardRepository
    {
        [CanBeNull]
        ShortcutData GetShortcutByPosition(Vector3 position);

        Vector3? GetShortcutPositionByPosition(Vector3 position);

        Vector2Int GetBoardSize();

        int GetCellSize();
    }
}
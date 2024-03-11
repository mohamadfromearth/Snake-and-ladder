using JetBrains.Annotations;
using UnityEngine;

namespace Data.Repositories
{
    public interface IBoardRepository
    {
        [CanBeNull]
        ShortcutData GetShortcutByPosition(Vector3 position);

        Vector3? GetShortcutPositionByPosition(Vector3 position);

        Vector3 GetPositionByIndices(Vector2Int indices);

        Vector2Int GetBoardSize();

        Vector2Int GetIndicesByPosition(Vector3 position);

        bool IsEndOfBoard(Vector3 position);

        int GetCellSize();
    }
}
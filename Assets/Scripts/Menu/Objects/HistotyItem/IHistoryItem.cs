using Data;
using UnityEngine;

namespace Menu
{
    public interface IHistoryItem
    {
        void SetData(PlayerScore playerScore);

        void SetParent(Transform parent);
        void Destroy();
    }
}
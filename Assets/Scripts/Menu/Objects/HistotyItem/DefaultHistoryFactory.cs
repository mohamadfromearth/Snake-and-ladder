using UnityEngine;

namespace Menu
{
    public class DefaultHistoryFactory : MonoBehaviour, IHistoryFactory
    {
        [SerializeField] private HistoryItemDataSetter historyItemPrefab;

        public IHistoryItem Create()
        {
            return Instantiate(historyItemPrefab);
        }
    }
}
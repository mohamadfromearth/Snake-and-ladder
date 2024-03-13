using System.Collections.Generic;
using Data.Repositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu
{
    public class HistoryController : MonoBehaviour
    {
        [Inject] private IPlayerRepository _playerRepository;
        [Inject] private IHistoryFactory _historyItemFactory;
        [SerializeField] private HorizontalLayoutGroup historyItemHorizontalLayoutGroup;
        [SerializeField] private GameObject historyPanel;

        private List<IHistoryItem> _historyItems;

        private void OnEnable()
        {
            _historyItems = new List<IHistoryItem>();

            foreach (var playerScore in _playerRepository.GetPlayersScore())
            {
                var item = _historyItemFactory.Create();
                item.SetParent(historyItemHorizontalLayoutGroup.transform);
                item.SetData(playerScore);
                _historyItems.Add(item);
            }
        }


        public void MenuClick()
        {
            foreach (var historyItem in _historyItems)
            {
                historyItem.Destroy();
            }

            _historyItems.Clear();

            historyPanel.SetActive(false);
        }
    }
}
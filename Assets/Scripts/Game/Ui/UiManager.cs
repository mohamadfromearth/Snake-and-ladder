using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;

        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private WinPanelDataSetter winPanelDataSetter;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button replayButton;
        private UnityAction _retryAction;


        public void SetTextTime(string text)
        {
            timeText.text = text;
        }

        public void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void HideGameOverPanel()
        {
            gameOverPanel.SetActive(false);
        }

        public void ShowWinPanel(int starsCount, string score, string time)
        {
            winPanel.SetActive(true);
            winPanelDataSetter.SetData(starsCount, score, time);
        }

        public void HideWinPanel()
        {
            winPanel.SetActive(false);
        }


        public void AddRetryListener(UnityAction action)
        {
            retryButton.onClick.AddListener(action);
        }

        public void AddReplayListener(UnityAction action)
        {
            replayButton.onClick.AddListener(action);
        }
    }
}
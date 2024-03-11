using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button retryButton;
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


    public void AddRetryListener(UnityAction action)
    {
        retryButton.onClick.AddListener(action);
    }
}
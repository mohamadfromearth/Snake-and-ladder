using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] GameObject historyPanel;


        public void OnPlayClick()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnHistoryClick()
        {
            historyPanel.SetActive(true);
        }
    }
}
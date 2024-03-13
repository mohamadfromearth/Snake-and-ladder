using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class HistoryItemDataSetter : MonoBehaviour, IHistoryItem
    {
        [SerializeField] private ImageLoader imageLoader;
        [SerializeField] private List<Image> stars;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private string filledStarSpriteName;
        [SerializeField] private string starSpriteName;

        public void SetData(PlayerScore playerScore)
        {
            SetStars(playerScore.StarCount);
            scoreText.text = "Score: " + playerScore.Score;
            timeText.text = "Time: " + playerScore.TimeText;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }


        private void SetStars(int starCount)
        {
            for (int i = 0; i < stars.Count; i++)
            {
                if (i < starCount)
                {
                    imageLoader.LoadImage(stars[i], filledStarSpriteName);
                }
                else
                {
                    imageLoader.LoadImage(stars[i], starSpriteName);
                }
            }
        }
    }
}
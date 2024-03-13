using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

namespace Ui
{
    public class WinPanelDataSetter : MonoBehaviour
    {
        [SerializeField] private ImageLoader imageLoader;

        [SerializeField] private List<Image> stars;
        [SerializeField] private string filledStarSpriteName;
        [SerializeField] private string starSpriteName;

        [SerializeField] private TextMeshProUGUI scoreText;

        [SerializeField] private TextMeshProUGUI timeText;


        public void SetData(int starCount, string score, string time)
        {
            SetStars(starCount);
            scoreText.text = score;
            timeText.text = time;
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
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Ui
{
    public class WinPanelDataSetter : MonoBehaviour
    {
        [SerializeField] private List<Image> stars;
        [SerializeField] private SpriteAtlas spriteAtlas;
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
                    stars[i].sprite = spriteAtlas.GetSprite(filledStarSpriteName);
                }
                else
                {
                    stars[i].sprite = spriteAtlas.GetSprite(starSpriteName);
                }
            }
        }
    }
}
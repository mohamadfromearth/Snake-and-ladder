using UnityEngine;

namespace Utils
{
    public class ScoreCalculator
    {
        private readonly float _multiplier;
        private readonly float _maxTime;

        public ScoreCalculator(float maxTime, float multiplier = 0.5f)
        {
            _multiplier = multiplier;
            _maxTime = maxTime;
        }

        public int CalculateScore(float remainedTime)
        {
            int score = Mathf.RoundToInt(_multiplier * remainedTime);
            return score;
        }

        public int CalculateStarsCount(float remainedTime)
        {
            if (remainedTime >= _maxTime - _maxTime / 3)
            {
                return 3;
            }

            if (remainedTime >= _maxTime - _maxTime / 2)
            {
                return 2;
            }

            return 1;
        }
    }
}
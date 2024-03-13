using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public struct PlayerScore
    {
        public int Score;
        public float Time;
        public string TimeText;
        public int StarCount;

        public PlayerScore(int score, float time, string timeText, int starCount)
        {
            Score = score;
            Time = time;
            TimeText = timeText;
            StarCount = starCount;
        }
    }

    [System.Serializable]
    public struct PlayerScoreList
    {
        public List<PlayerScore> PlayerScores;

        public PlayerScoreList(List<PlayerScore> playerScores)
        {
            PlayerScores = playerScores;
        }
    }
}
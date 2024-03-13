using System.Collections.Generic;
using UnityEngine;

namespace Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<PlayerScore> _players;
        private const string PlayerScoreListKey = "PLAYER_SCORE_LIST_KEY";

        public PlayerRepository()
        {
            _players = new List<PlayerScore>();
            var playerScoreListJson = PlayerPrefs.GetString(PlayerScoreListKey, "");
            if (playerScoreListJson != "")
            {
                _players = JsonUtility.FromJson<PlayerScoreList>(playerScoreListJson).PlayerScores;
            }
        }

        public void SavePlayerScore(PlayerScore playerScore)
        {
            _players.Add(playerScore);
            var playerScoreListJson = JsonUtility.ToJson(new PlayerScoreList(_players));
            PlayerPrefs.SetString(PlayerScoreListKey, playerScoreListJson);
        }

        public List<PlayerScore> GetPlayersScore()
        {
            return _players;
        }
    }
}
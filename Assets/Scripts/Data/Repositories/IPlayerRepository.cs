using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IPlayerRepository
    {
        void SavePlayerScore(PlayerScore playerScore);
        List<PlayerScore> GetPlayersScore();
    }
}
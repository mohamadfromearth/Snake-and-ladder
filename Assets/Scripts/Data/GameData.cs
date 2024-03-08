using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "So/GameData",fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        public int cellSize;
        public int row;
        public int column;
    }
}
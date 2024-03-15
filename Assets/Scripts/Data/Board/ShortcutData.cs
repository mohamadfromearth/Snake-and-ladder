using Data.Board;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "So/ShortcutData", fileName = "ShortcutData")]
    public class ShortcutData : ScriptableObject
    {
        public Color color;
        public Vector2Int start;
        public Vector2Int end;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public ShortcutType shortcutType;
    }
}
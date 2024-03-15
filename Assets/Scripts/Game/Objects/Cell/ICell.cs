using UnityEngine;

namespace Cell
{
    public interface ICell
    {
        public int Size { get; }
        public void SetPosition(Vector2 position);

        public Transform GetTransform();
    }
}
using UnityEngine;


namespace GridStructure
{
    public struct Cell
    {
        public Vector2 Position { get; }

        public Cell(Vector2 position)
        {
            this.Position = position;
        }
    }
}
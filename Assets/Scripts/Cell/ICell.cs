using UnityEngine;

public interface ICell
{
    public int Size { get; }
    public void SetPosition(Vector2 position);
}
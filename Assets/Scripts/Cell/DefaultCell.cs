using System;
using UnityEngine;

public class DefaultCell : MonoBehaviour, ICell
{
    public int Size { get; private set; }
    [SerializeField] private int size;

    private void Awake()
    {
        Size = size;
    }


    public void SetPosition(Vector2 position)
    {
        Debug.Log("Set cell position to " + position);
        transform.position = position;
    }
}
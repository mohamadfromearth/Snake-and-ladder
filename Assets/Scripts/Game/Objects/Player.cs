using System;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveTime;

    public float MoveTime { get; private set; }

    private Action _moveFinished;

    private void Start()
    {
        MoveTime = moveTime;
    }


    public void Move(Vector2 position)
    {
        transform.DOMove(position, moveTime);
        Invoke(nameof(InvokeMoveFinished), moveTime);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void AddMoveFinishedListener(Action moveFinished)
    {
        _moveFinished = moveFinished;
    }

    private void InvokeMoveFinished()
    {
        _moveFinished?.Invoke();
    }
}
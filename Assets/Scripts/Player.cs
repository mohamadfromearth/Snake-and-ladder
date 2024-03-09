using System;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveTime;

    private Action _moveFinished;


    public void Move(Vector2 position)
    {
        transform.DOMove(position, moveTime);
        Invoke(nameof(InvokeMoveFinished), moveTime);
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
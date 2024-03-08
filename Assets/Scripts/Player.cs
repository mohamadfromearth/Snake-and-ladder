using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveTime;


    public void Move(Vector2 position)
    {
        transform.DOMove(position, moveTime);
    }
}
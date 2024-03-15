using System;
using DG.Tweening;
using Event;
using Event.EventsData;
using Game.Event;
using UnityEngine;
using Zenject;

namespace Game.Objects
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveTime;

        public EventChannel Channel { get; set; }


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
}
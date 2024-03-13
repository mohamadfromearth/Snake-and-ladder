using System;
using UnityEngine;

namespace Utils
{
    public class CountDownTimer
    {
        private float _time;
        public float CurrentTime { get; private set; }
        public bool IsRunning { get; private set; } = false;

        private Action _timeOverAction;

        public CountDownTimer(float time)
        {
            _time = time;
            CurrentTime = _time;
        }

        public void Tick(float deltaTime)
        {
            if (IsRunning == false) return;

            CurrentTime -= deltaTime;

            if (CurrentTime < 0)
            {
                CurrentTime = 0;
                IsRunning = false;
                _timeOverAction?.Invoke();
            }
        }

        public void Pause()
        {
            IsRunning = false;
        }

        public void Play()
        {
            IsRunning = true;
        }

        public void Restart()
        {
            CurrentTime = _time;
            IsRunning = true;
        }

        public string GetTimeText()
        {
            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(CurrentTime / 60);
            int seconds = Mathf.FloorToInt(CurrentTime % 60);

            // Format the time into a string
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

            return timeString;
        }

        public void SetTimeOverListener(Action action)
        {
            _timeOverAction = action;
        }
    }
}
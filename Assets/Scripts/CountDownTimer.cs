using System;
using UnityEngine;

public class CountDownTimer
{
    private float _time;
    private float _currentTime;
    public bool IsRunning { get; private set; } = false;

    private Action _timeOverAction;

    public CountDownTimer(float time)
    {
        _time = time;
        _currentTime = _time;
    }

    public void Tick(float deltaTime)
    {
        if (IsRunning == false) return;

        _currentTime -= deltaTime;

        if (_currentTime < 0)
        {
            _currentTime = 0;
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
        _currentTime = _time;
        IsRunning = true;
    }

    public string GetTimeText()
    {
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(_currentTime / 60);
        int seconds = Mathf.FloorToInt(_currentTime % 60);

        // Format the time into a string
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        return timeString;
    }

    public void SetTimeOverListener(Action action)
    {
        _timeOverAction = action;
    }
}
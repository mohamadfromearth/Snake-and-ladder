using System;
using System.Collections.Generic;
using Event.EventsData;
using UnityEngine;

namespace Event
{
    public class EventChannel
    {
        private readonly Dictionary<Type, Action> _actionsDictionary = new Dictionary<Type, Action>();
        private readonly Dictionary<Type, IEventData> _eventDataDictionary = new Dictionary<Type, IEventData>();


        public EventChannel()
        {
            Debug.Log("EventChanel is creating...");
        }

        public void AddAction<T>() where T : IEventData
        {
            _actionsDictionary[typeof(T)] = null;
        }

        public void Subscribe<T>(Action action) where T : IEventData
        {
            _actionsDictionary[typeof(T)] += action;
        }

        public void UnSubscribe<T>(Action action)
        {
            _actionsDictionary[typeof(T)] -= action;
        }

        public T GetData<T>() where T : IEventData
        {
            return (T)_eventDataDictionary[typeof(T)];
        }

        public void Rise<T>(IEventData data)
        {
            _eventDataDictionary[typeof(T)] = data;
            _actionsDictionary[typeof(T)].Invoke();
        }
    }
}
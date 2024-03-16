using UnityEngine;

namespace Event.EventsData
{
    public struct TimeOver : IEventData
    {
        public static TimeOver Instance = new TimeOver();
    }
}
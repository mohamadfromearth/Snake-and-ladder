using System;
using Event;
using Event.EventsData;
using Zenject;

namespace Game.Event
{
    public class EventInstaller
    {
         private EventChannel _eventChannel;


        [Inject]
        private void Construct(EventChannel eventChannel)
        {
            _eventChannel = eventChannel;
            
            _eventChannel.AddAction<PlayerMoveFinishedEventData>();

        }

      
    }
}
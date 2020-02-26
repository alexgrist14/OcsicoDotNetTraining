using System;

namespace OcsicoTraining.Stasulevich.Lesson7.CountDownClock
{
    public class MessageSenderEventArgs : EventArgs
    {
        public EventInfo EventInfo { get; set; }

        public MessageSenderEventArgs(EventInfo eventInfo)
        {
            EventInfo = eventInfo;
        }
    }
}

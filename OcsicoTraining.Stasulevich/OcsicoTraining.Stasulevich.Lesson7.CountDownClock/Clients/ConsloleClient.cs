using System;

namespace OcsicoTraining.Stasulevich.Lesson7.CountDownClock.Clients
{
    public class ConsloleClient
    {
        public void WriteToConsole(EventInfo eventInfo) => Console.WriteLine($"{eventInfo.Time.ToLongTimeString()} {eventInfo.Message}");
    }
}

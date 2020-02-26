using System;
using System.IO;

namespace OcsicoTraining.Stasulevich.Lesson7.CountDownClock.Clients
{
    public class FileClient
    {
        private static readonly object SynchronizationObject = new object();
        private readonly string file = "logs.txt";

        public void WriteToFile(EventInfo eventInfo)
        {
            lock (SynchronizationObject)
            {
                File.AppendAllText(file, $"{eventInfo.Time.ToLongTimeString()} {eventInfo.Message}{Environment.NewLine}");
            }
        }
    }
}

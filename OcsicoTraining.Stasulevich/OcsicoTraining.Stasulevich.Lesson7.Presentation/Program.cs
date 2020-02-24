using System;
using System.Threading;
using OcsicoTraining.Stasulevich.Lesson7.CountDownClock;
using OcsicoTraining.Stasulevich.Lesson7.CountDownClock.Clients;

namespace OcsicoTraining.Stasulevich.Lesson7.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var fileClient = new FileClient();
            var consoleClient = new ConsloleClient();
            var timerService = new TimerService();

            timerService.OnOneSecond += (sender, args) => consoleClient.WriteToConsole(args.EventInfo);
            timerService.OnOneSecond += (sender, args) => fileClient.WriteToFile(args.EventInfo);

            timerService.Start();

            Thread.Sleep(20000);
            timerService.Stop();
        }
    }
}

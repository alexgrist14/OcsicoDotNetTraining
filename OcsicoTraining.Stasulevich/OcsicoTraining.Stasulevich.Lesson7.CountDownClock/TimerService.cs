using System;
using System.Threading;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson7.CountDownClock
{
    public class TimerService
    {
        private readonly CancellationToken cancellationToken;
        private readonly CancellationTokenSource cancellationTokenSource;

        public event EventHandler<MessageSenderEventArgs> OnOneSecond;
        public event EventHandler<MessageSenderEventArgs> OnTenSecond;

        public TimerService()
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        public void Start() => Task.Run(RunTimer, cancellationToken);

        public void Stop() => cancellationTokenSource.Cancel();

        private void RunTimer()
        {
            var counter = 1;

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                counter++;

                var eventInfo = new EventInfo { Message = "1s", Time = DateTime.Now };

                OnOneSecond?.Invoke(this, new MessageSenderEventArgs(eventInfo));
                if (counter % 10 == 0)
                {
                    eventInfo = new EventInfo { Message = "10s", Time = DateTime.Now };
                    OnTenSecond?.Invoke(this, new MessageSenderEventArgs(eventInfo));
                }
            }
        }
    }
}

using System.Timers;
using Timer = System.Timers.Timer;

namespace DotNet4
{
    public static class TaskCompletionSourceExample
    {
        public static Task EventExample()
        {
            var tcs = new TaskCompletionSource();

            var timer = new Timer(3000);

            timer.Elapsed += (_, _) =>
            {
                Thread.Sleep(1000);

                tcs.SetResult();
            };

            timer.Start();

            return tcs.Task;
        }

        public static Task ThreadToTaskExample()
        {
            var tcs = new TaskCompletionSource();

            new Thread(() =>
            {
                Thread.Sleep(1000);

                tcs.SetResult();
            });

            return tcs.Task;
        }
    }
}

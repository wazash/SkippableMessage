using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public static class PrintSkippableMessage
    {
        public static async Task Print(string message, int timer)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var enterPressedTask = Task.Run(() =>
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    cancellationTokenSource.Cancel();
                }

            });

            await SkipMessage(message, timer, cancellationTokenSource.Token);

            await enterPressedTask;
        }

        private static Task SkipMessage(string message, int timer, CancellationToken cancellationToken)
        {
            Task task = null;

            task = Task.Run(() =>
            {
                foreach (var item in message)
                {
                    Console.Write(item);
                    Thread.Sleep(timer);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        timer = 0;
                    }
                }
            });

            return task;
        }
    }
}

///-----------------------------------------------------------------
///   File:         TaskExtensions.cs
///   Author:       Andre Laskawy           
///   Date:         30.09.2018 14:34:00
///-----------------------------------------------------------------

namespace Nanomite
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="TaskExtensions"/>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Awaits the result.
        /// </summary>
        /// <param name="awaitingFunc">The awaiting function.</param>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task AwaitResult(this Func<bool> awaitingFunc, int timeoutInSeconds = 30)
        {
            DateTime dt = DateTime.Now;
            while (!awaitingFunc.Invoke())
            {
                await Task.Delay(0);
                if (dt.AddSeconds(timeoutInSeconds) < DateTime.Now)
                {
                    throw new TimeoutException("Timeout during awaiting task result");
                }
            }
        }

        /// <summary>
        /// Awaits the specified task synchronously.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        public static void Await(this Task task, int timeoutInSeconds = 30)
        {
            bool done = false;
            new Task(async () =>
            {
                await task;
                done = true;
            }).Start();

            DateTime dt = DateTime.Now;
            while (!done)
            {
                Thread.Sleep(1);
                if (dt.AddSeconds(timeoutInSeconds) < DateTime.Now)
                {
                    throw new TimeoutException("Timeout during awaiting task.");
                }
            }
        }
    }
}

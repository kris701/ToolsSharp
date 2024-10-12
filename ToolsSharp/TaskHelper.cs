namespace ToolsSharp
{
    /// <summary>
    /// A set of methods to make it easier to work with <seealso cref="Task"/>s
    /// </summary>
    public static class TaskHelper
    {
        /// <summary>
        /// A method to execute a <seealso cref="IList{T}"/> of <seealso cref="Task"/>s that return <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks">List of tasks to execute</param>
        /// <param name="runParallel">Whether or not to run the tasks parallel or not</param>
        public static void RunTasks<T>(List<Task<T>> tasks, bool runParallel)
        {
            if (runParallel)
            {
                Parallel.ForEach(tasks, task => task.Start());
                Task.WaitAll(tasks.ToArray());
            }
            else
            {
                foreach (var task in tasks)
                {
                    task.Start();
                    task.Wait();
                }
            }
        }

        /// <summary>
        /// An async method to execute a <seealso cref="IList{T}"/> of <seealso cref="Task"/>s that return <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks">List of tasks to execute</param>
        /// <param name="runParallel">Whether or not to run the tasks parallel or not</param>
        /// <param name="cancellationToken">A <seealso cref="CancellationToken"/> token. Note, this only does something directly if <paramref name="runParallel"/> is false, otherwise its expected that the tasks themselfs have the same <seealso cref="CancellationToken"/></param>
        public static async Task RunTasksAsync<T>(List<Task<T>> tasks, bool runParallel, CancellationToken cancellationToken)
        {
            if (runParallel)
            {
                Parallel.ForEach(tasks, task => task.Start());
                await Task.WhenAll(tasks.ToArray());
            }
            else
            {
                foreach (var task in tasks)
                {
                    task.Start();
                    await task.WaitAsync(cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            }
        }
    }
}
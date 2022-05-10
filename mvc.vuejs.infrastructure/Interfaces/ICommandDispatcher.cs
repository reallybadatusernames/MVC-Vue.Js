﻿using System.Threading.Tasks;

namespace mvc.vuejs.infrastructure
{
    /// <summary>
    /// Passed around to all allow dispatching a command and to be mocked by unit tests
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        /// <typeparam name="TParameter">Command Type</typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        void Dispatch<TParameter>(TParameter command) where TParameter : ICommand;

        /// <summary>
        /// Dispatches a command to it's handler asynchronously
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        /// <returns></returns>
        Task DispatchAsync<TParameter>(TParameter command) where TParameter : ICommand;


    }
}

namespace HomeLi.Contracts
{
    public interface ILoggerManager
    {
        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInfo(string message);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarn(string message);

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogDebug(string message);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogError(string message);
    }
}
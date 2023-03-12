namespace CfxUtils.Shared.Logging
{
    /// <summary>
    /// Defines logging severity levels for the current resource.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logs that contain the most detailed messages, and may contain sensitive data that should never be shown in a production environment
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logs that primarily contain information useful for debugging
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs that track the general flow of the application
        /// </summary>
        Information = 2,

        /// <summary>
        /// Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the
        /// application execution to stop
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Logs that highlight when the current execution is stopped due to an error
        /// </summary>
        Error = 4,

        /// <summary>
        /// Specifies that the current resource shouldn't output any logs
        /// </summary>
        None = 5,
    }
}
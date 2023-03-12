using CfxUtils.Shared.Convar;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;

namespace CfxUtils.Shared.Logging 
{
    /// <summary>
    /// Responsible for handling logging and logging levels
    /// </summary>
    public class Log : BaseScript
    {
        /// <summary>
        /// The current log level of this resource
        /// </summary>
        public static LogLevel Level => _logLevel ??= _logLevelConvar.Value;

        private static ReplicatedConvar<LogLevel> _logLevelConvar = new ($"{API.GetCurrentResourceName()}_LogLevel", LogLevel.Information);
        private static LogLevel? _logLevel;

        private static Dictionary<LogLevel, string> _logToColorMap = new ()
        {
            [LogLevel.Trace] = LogColors.Magenta,
            [LogLevel.Debug] = LogColors.Red,
            [LogLevel.Information] = LogColors.Blue,
            [LogLevel.Warning] = LogColors.Yellow,
            [LogLevel.Error] = LogColors.DarkRed,
        };

        /// <inheritdoc cref="LogLevel.Trace" />
        public static void Trace(string message)
        {
            WriteLine(LogLevel.Trace, message);
        }

        /// <inheritdoc cref="LogLevel.Debug" />
        public static void Debug(string message)
        {
            WriteLine(LogLevel.Debug, message);
        }

        /// <inheritdoc cref="LogLevel.Information" />
        public static void Information(string message)
        {
            WriteLine(LogLevel.Information, message);
        }

        /// <inheritdoc cref="LogLevel.Warning" />
        public static void Warning(string message)
        {
            WriteLine(LogLevel.Warning, message);
        }

        /// <inheritdoc cref="LogLevel.Error" />
        public static void Error(string message)
        {
            WriteLine(LogLevel.Error, message);
        }

        /// <inheritdoc cref="LogLevel.Error" />
        public static void Error(Exception error)
        {
            WriteLine(LogLevel.Error, $"The following error has occurred - {error.StackTrace}");
        }

        /// <summary>
        /// Writes a log message to the console
        /// </summary>
        /// <param name="level">The log level of the message</param>
        /// <param name="message">The message to send</param>
        public static void WriteLine(LogLevel level, string message)
        {
            if (level == LogLevel.None || level < Level)
            {
                return;
            }

            CitizenFX.Core.Debug.WriteLine($"{_logToColorMap[level]}[{level}]{LogColors.Reset}: {message}{LogColors.Reset}");
        }
    }
}
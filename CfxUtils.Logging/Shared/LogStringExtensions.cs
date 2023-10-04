namespace CfxUtils.Logging
{
    public static class LogStringExtensions
    {
        /// <summary>
        /// Formats this string to be outputted in white in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToWhite(this string logMessage)
        {
            return LogFormatter.ToWhite(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in red in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToRed(this string logMessage)
        {
            return LogFormatter.ToRed(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in green in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToGreen(this string logMessage)
        {
            return LogFormatter.ToGreen(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in yellow in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToYellow(this string logMessage)
        {
            return LogFormatter.ToYellow(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in blue in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToBlue(this string logMessage)
        {
            return LogFormatter.ToBlue(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in cyan in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToCyan(this string logMessage)
        {
            return LogFormatter.ToCyan(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in magenta in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToMagenta(this string logMessage)
        {
            return LogFormatter.ToMagenta(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in dark red in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToDarkRed(this string logMessage)
        {
            return LogFormatter.ToDarkRed(logMessage);
        }

        /// <summary>
        /// Formats this string to be outputted in dark blue in the console
        /// </summary>
        /// <param name="logMessage">The string to format</param>
        /// <returns>The formatted message</returns>
        public static string ToDarkBlue(this string logMessage)
        {
            return LogFormatter.ToDarkBlue(logMessage);
        }
    }
}
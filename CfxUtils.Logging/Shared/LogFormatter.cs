namespace CfxUtils.Logging
{
    public static class LogFormatter
    {
        /// <summary>
        /// Formats the message to be outputted in white in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToWhite(string logMessage)
        {
            return FormatMessage(LogColors.White, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in red in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToRed(string logMessage)
        {
            return FormatMessage(LogColors.Red, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in green in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToGreen(string logMessage)
        {
            return FormatMessage(LogColors.Green, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in yellow in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToYellow(string logMessage)
        {
            return FormatMessage(LogColors.Yellow, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in blue in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToBlue(string logMessage)
        {
            return FormatMessage(LogColors.Blue, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in cyan in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToCyan(string logMessage)
        {
            return FormatMessage(LogColors.Cyan, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in magenta in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToMagenta(string logMessage)
        {
            return FormatMessage(LogColors.Magenta, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in dark red in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToDarkRed(string logMessage)
        {
            return FormatMessage(LogColors.DarkRed, logMessage);
        }

        /// <summary>
        /// Formats the message to be outputted in dark blue in the console
        /// </summary>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        public static string ToDarkBlue(string logMessage)
        {
            return FormatMessage(LogColors.DarkBlue, logMessage);
        }

        /// <summary>
        /// Formats the message
        /// </summary>
        /// <param name="colorCode">The color code of the wanted color</param>
        /// <param name="logMessage">The message to format</param>
        /// <returns>The formatted message</returns>
        private static string FormatMessage(string colorCode, string logMessage)
        {
            return colorCode + logMessage + LogColors.Reset;
        }
    }
}
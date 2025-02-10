namespace PhonePadChallenge.Common
{
    /// <summary>
    /// Application-wide constants used across different implementations
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Character marking the end of input
        /// </summary>
        public const char END_MARKER = '#';

        /// <summary>
        /// Character used for backspace functionality
        /// </summary>
        public const char BACKSPACE = '*';

        /// <summary>
        /// Character representing a space
        /// </summary>
        public const char SPACE = ' ';

        /// <summary>
        /// Maximum allowed length for input strings
        /// </summary>
        public const int MAX_INPUT_LENGTH = 1000;

        /// <summary>
        /// Dictionary mapping for phone pad keys and their corresponding characters
        /// </summary>
        public static readonly IReadOnlyDictionary<char, string> KEYPAD = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };
    }
} 
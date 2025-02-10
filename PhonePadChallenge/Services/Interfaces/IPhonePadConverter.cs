namespace PhonePadChallenge.Services;

/// <summary>
/// Interface for phone pad text conversion implementations
/// </summary>
public interface IPhonePadConverter
{
    /// <summary>
    /// Converts a string of numbers into text
    /// </summary>
    /// <param name="input">String of numbers representing button presses</param>
    /// <returns>The converted text</returns>
    /// <exception cref="ArgumentException">Thrown when input is invalid</exception>
    string Convert(string input);

    /// <summary>
    /// Converts text back into the sequence of key
    /// </summary>
    /// <param name="input">Text to convert back to key presses</param>
    /// <returns>String of numbers representing the key presses needed, ending with #</returns>
    /// <exception cref="ArgumentException">Thrown when input contains unsupported characters</exception>
    string Reverse(string input);
}
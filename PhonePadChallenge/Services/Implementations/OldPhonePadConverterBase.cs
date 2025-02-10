using System.Text;
using PhonePadChallenge.Common;

namespace PhonePadChallenge.Services;

public abstract class OldPhonePadConverterBase
{
    /// <summary>
    /// Convert text back to key presses
    /// </summary>
    public string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty");

        var result = new StringBuilder();
        var lastKey = '%';
        
        // For each character in the input
        foreach (char c in input.ToUpper()) // Convert to upper because our keypad is in upper
        {
            bool found = false;
            
            // Special case for space
            if (c == ' ')
            {
                if (lastKey != '\0') result.Append(' ');
                result.Append('0');
                lastKey = '0';
                continue;
            }

            // Look through each key in the keypad
            foreach (var key in Constants.KEYPAD)
            {
                // Find position of character in the key's values
                int position = key.Value.IndexOf(c);
                if (position != -1)
                {
                    // Add space only if it's the same key than the last one
                    if (lastKey != '\0' && lastKey == key.Key) 
                        result.Append(' ');
                    
                    // Add the key pressed the right number of times
                    // position + 1 because we need to press once for first char, twice for second, etc.
                    result.Append(new string(key.Key, position + 1));
                    
                    found = true;
                    lastKey = key.Key;
                    break;
                }
            }

            if (!found)
                throw new ArgumentException($"Character '{c}' is not supported");
        }

        // Don't forget to add the end marker
        result.Append(Constants.END_MARKER);
        
        return result.ToString();
    }
}

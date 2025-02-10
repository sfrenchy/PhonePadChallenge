using PhonePadChallenge.Common;

namespace PhonePadChallenge.Services
{
    /// <summary>
    /// Converts input string to text with an iterative approach
    /// </summary>
    public class OldPhonePadIterativeConverter : OldPhonePadConverterBase, IPhonePadConverter
    {
        public String Convert(string input) 
        {
            // First make sure input is valid
            if (input.Any(c => !Constants.KEYPAD.ContainsKey(c) && c != Constants.END_MARKER && c != Constants.BACKSPACE && c != Constants.SPACE))
                throw new ArgumentException($"This method supports only valid phone pad characters");
            if (input[input.Length - 1] != Constants.END_MARKER)
                throw new ArgumentException($"Input must finish by {Constants.END_MARKER} character");

            // Keep track of what we're doing
            char lastCharacter = '%';  // Using % as it's not in our keypad
            int pressCount = 0;
            string result = "";   // TODO: maybe use StringBuilder for better perf?

            foreach (char character in input)
            {
                // Skip spaces but reset our counters
                if (character == Constants.SPACE)
                {
                    pressCount = 0;
                    lastCharacter = Constants.SPACE;
                    continue;
                }
                    
                // We're done when we hit #
                if (character == Constants.END_MARKER)
                    return result;

                // Count how many times we pressed the same key
                if (character == lastCharacter)
                    pressCount++;
                else
                    pressCount = 0;

                // Need to remove the last char if:
                // - we're pressing the same key again (cycling letters)
                // - or if we hit backspace
                if (pressCount > 0 || character == Constants.BACKSPACE)
                    result = result[..^1];
                
                // Add the new letter (unless it's backspace)
                if (character != Constants.BACKSPACE && Constants.KEYPAD.ContainsKey(character))
                {
                    var letters = Constants.KEYPAD[character];
                    result += letters[pressCount % letters.Length];
                }
                
                lastCharacter = character;
            }

            return result;
        }
    }
} 
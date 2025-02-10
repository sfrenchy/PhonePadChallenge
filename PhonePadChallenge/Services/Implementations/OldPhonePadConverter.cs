using System.Text;
using PhonePadChallenge.Common;

namespace PhonePadChallenge.Services;

/// <summary>
/// Converts input string to text using LINQ
/// </summary>
public class OldPhonePadLinqConverter : OldPhonePadConverterBase, IPhonePadConverter
{
    public string Convert(string input)
    {
        ValidateInput(input);

        var groupedKeys = GroupConsecutiveKeys(input);
        return ProcessGroups(groupedKeys);
    }

    private void ValidateInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty");
            
        if (!input.EndsWith(Constants.END_MARKER))
            throw new ArgumentException($"Input must end with {Constants.END_MARKER}");
            
        if (input.Length > Constants.MAX_INPUT_LENGTH)
            throw new ArgumentException($"Input length cannot exceed {Constants.MAX_INPUT_LENGTH} characters");
            
        if (input.Where(c => c != Constants.END_MARKER && c != Constants.BACKSPACE && c != Constants.SPACE)
            .Any(c => !Constants.KEYPAD.ContainsKey(c)))
            throw new ArgumentException("Input contains invalid characters");
    }

    private IEnumerable<(char Key, int Count)> GroupConsecutiveKeys(string input)
    {
        return input.Replace("#","")
            .Aggregate(new List<(char Character, int Count)>(), (acc, c) =>
            {
                if (acc.Count == 0 || acc.Last().Character != c)
                    acc.Add((c, 1));
                else
                    acc[acc.Count - 1] = (c, acc.Last().Count + 1);

                return acc;
            });
    }

    private string ProcessGroups(IEnumerable<(char Key, int Count)> groups)
    {
        var result = new StringBuilder();

        foreach (var (key, count) in groups)
        {
            switch (key)
            {
                case Constants.SPACE:
                    continue;

                case Constants.BACKSPACE:
                    HandleBackspace(result, count);
                    continue;

                default:
                    HandleKeyPress(result, key, count);
                    break;
            }
        }

        return result.ToString();
    }

    private void HandleBackspace(StringBuilder result, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (result.Length > 0)
                result.Length--;
        }
    }

    private void HandleKeyPress(StringBuilder result, char key, int count)
    {
        if (Constants.KEYPAD.TryGetValue(key, out string? letters))
        {
            var pressCount = count % letters.Length;
            if (pressCount == 0)
                pressCount = letters.Length;
            result.Append(letters[pressCount - 1]);
        }
    }
}
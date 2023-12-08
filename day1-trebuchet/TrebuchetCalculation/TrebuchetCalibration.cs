using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TrebuchetCalculation;

public partial class TrebuchetCalibration
{
    private static readonly Dictionary<string, int> ValidLetterDigitMapping = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };

    public static async Task<IEnumerable<string>> ReadCalibrationDocument(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int CalculateCalibrationValue(IEnumerable<string> calibrationValues)
    {
        return calibrationValues.Take(800).Select(
            x =>
            {
                var matches = LetterDigitMatcher().Matches(x);
                var firstDigit = ParseMatch(matches.First());
                var lastDigit = ParseMatch(matches.Last());
                Debug.WriteLine("String: " + x);
                foreach(var match in matches) {              
                    Debug.WriteLine(match);
                }
                Debug.WriteLine("Answer: " + firstDigit.ToString ()+ lastDigit.ToString());
                Debug.WriteLine("-----------------");
               
                return int.Parse(firstDigit.ToString() + lastDigit.ToString());
            }
        )
        .Sum();
    }

    [GeneratedRegex("(\\d|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine))")]
    private static partial Regex LetterDigitMatcher();

    private static int ParseMatch(Match match)
    {
        var validDirectDigit = int.TryParse(match.Value, out int directDigit);
        if (validDirectDigit)
        {
            return directDigit;
        }

        var validLetterDigit = ValidLetterDigitMapping.TryGetValue(match.Value, out int letterDigit);
        if (validLetterDigit)
        {
            return letterDigit;
        }

        throw new Exception("Unable to parse given match to digit");
    }
}

namespace TrebuchetCalculation;

public class TrebuchetCalibration
{
    public static async Task<IEnumerable<string>> ReadCalibrationDocument(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int CalculateCalibrationValue(IEnumerable<string> calibrationValues)
    {
        return calibrationValues.Select(
            x => {
                var firstDigit = x.First(y => char.IsDigit(y));
                var lastDigit = x.Last(y => char.IsDigit(y));
                var number = new string(new[] {firstDigit, lastDigit});
                return int.Parse(number);
            }
        )
        .Sum();
    }
}

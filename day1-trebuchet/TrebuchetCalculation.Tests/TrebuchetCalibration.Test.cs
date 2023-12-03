namespace TrebuchetCalculation.Tests;

public class TrebuchetCalibrationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TrebuchetCalculation_GivenCalibrationValues_ReturnsOverallCalibrationValue()
    {
        var expected = 142;

        List<string> calibrationValues = new()
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        };

        var result = TrebuchetCalibration.CalculateCalibrationValue(calibrationValues);

        Assert.That(result, Is.EqualTo(expected));
    }
}
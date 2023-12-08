namespace TrebuchetCalculation.Tests;

public class TrebuchetCalibrationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculateCalibrationValue_GivenCalibrationValues_ReturnsOverallCalibrationValue()
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

    [Test]
    public void CalculateCalibrationValue_GivenCalibrationValuesWithStringNumbers_ReturnsOverallCalibrationValue()
    {
        var expected = 281;

        List<string> calibrationValues = new()
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        var result = TrebuchetCalibration.CalculateCalibrationValue(calibrationValues);

        Assert.That(result, Is.EqualTo(expected));
    }

        [Test]
    public void CalculateCalibrationValue_GivenCalibrationValuesWithMergedCase_ReturnsOverallCalibrationValue()
    {
        var expected = 52;

        List<string> calibrationValues = new()
        {
            "5mfknkone4cphtbrtj1eightwon"
        };

        var result = TrebuchetCalibration.CalculateCalibrationValue(calibrationValues);

        Assert.That(result, Is.EqualTo(expected));
    }
}
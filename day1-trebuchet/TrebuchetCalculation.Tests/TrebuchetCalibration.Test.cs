using System.Collections.Generic;

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

        List<string> calibrationValues = new List<string> {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        };

        var sut = new TrebuchetCalibration();

        var result = sut.CalculateCalibrationValue(calibrationValues);

        Assert.That(result, Is.EqualTo(expected));
    }
}
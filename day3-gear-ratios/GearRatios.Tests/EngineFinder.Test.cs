namespace GearRatios.Tests;

public class EngineFinderTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindPartNumberSum_GivenSchematic_ReturnsCorrectPartSum()
    {
        var schematic = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        var result = EngineFinder.FindPartNumberSum(schematic);

        var expectedPartSum = 4361;

        Assert.That(result, Is.EqualTo(expectedPartSum));
    }

        [Test]
    public void CalculateGearRatioSum_GivenSchematic_ReturnsCorrectGearRatioSum()
    {
        var schematic = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        var result = EngineFinder.CalculateGearRatioSum(schematic);

        var expectedGearRatioSum = 467835;

        Assert.That(result, Is.EqualTo(expectedGearRatioSum));
    }
}
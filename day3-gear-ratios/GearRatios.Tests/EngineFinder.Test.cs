namespace GearRatios.Tests;

public class EngineFinderTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EngineFinder_GivenSchematic_ReturnsCorrectPartSum()
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

        var result = EngineFinder.ReadSchematic(schematic);

        var expectedPartSum = 4361;

        Assert.That(result, Is.EqualTo(expectedPartSum));
    }
}
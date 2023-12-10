namespace CubeConundrum.Tests;

public class Tests
{
    private readonly Bag DefaultLoadedBag = new(14, 13, 12);

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GameValidator_GivenGameRecords_ReturnsExpectedIdSum()
    {
        var gameRecords = new List<string>()
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        var expectedIdSum = 8;

        var result = CubeGameValidator.GameValidator(gameRecords, DefaultLoadedBag);

        Assert.That(result, Is.EqualTo(expectedIdSum));
    }

    [Test]
    public void GameValidator_GivenGameRecordsWithMaxValues_ReturnsExpectedIdSum()
    {
        var gameRecords = new List<string>()
        {
            "Game 1: 12 red, 13 green, 14 blue"
        };

        var expectedIdSum = 1;

        var result = CubeGameValidator.GameValidator(gameRecords, DefaultLoadedBag);

        Assert.That(result, Is.EqualTo(expectedIdSum));
    }

    [Test]
    public void GameValidator_GivenGameRecordsWithAllInvalidValues_ReturnsExpectedIdSum()
    {
        var gameRecords = new List<string>()
        {
            "Game 1: 13 red, 14 green, 15 blue"
        };

        var expectedIdSum = 0;

        var result = CubeGameValidator.GameValidator(gameRecords, DefaultLoadedBag);

        Assert.That(result, Is.EqualTo(expectedIdSum));
    }

    [Test]
    public void GameValidator_GivenGameRecordsWithSingleInvalidValue_ReturnsExpectedIdSum()
    {
        var gameRecords = new List<string>()
        {
            "Game 1: 12 red, 13 green, 15 blue"
        };

        var expectedIdSum = 0;

        var result = CubeGameValidator.GameValidator(gameRecords, DefaultLoadedBag);

        Assert.That(result, Is.EqualTo(expectedIdSum));
    }

    [Test]
    public void GameValidator_GivenGameRecordsWithSingleCube_ReturnsExpectedIdSum()
    {
        var gameRecords = new List<string>()
        {
            "Game 1: 12 red"
        };

        var expectedIdSum = 1;

        var result = CubeGameValidator.GameValidator(gameRecords, DefaultLoadedBag);

        Assert.That(result, Is.EqualTo(expectedIdSum));
    }
}

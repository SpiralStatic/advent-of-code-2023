
namespace ScratchCards.Tests;

public class ScratchCardsWinningsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculateWinnings_GivenScratchCardLines_ReturnsExpectedScratchCardWinningsSum()
    {
        var input = new List<string> {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        var result = ScratchCardsWinnings.CalculateWinnings(input);

        var expectedScratchCardSum = 13;

        Assert.That(result, Is.EqualTo(expectedScratchCardSum));
    }

    [Test]
    public void CalculateTotalScratchcards_GivenScratchCardLines_ReturnsExpectedScratchCardWinningsSum()
    {
        var input = new List<string> {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", // 4 - 2,3,4,5 
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", // 2 - 3,4
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", // 2 - 4,5
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", // 1 - 5
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", // 0
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"  // 0
        };

        var result = ScratchCardsWinnings.CalculateTotalScratchcards(input);

        var expectedScratchcards = 30;

        Assert.That(result, Is.EqualTo(expectedScratchcards));
    }
}
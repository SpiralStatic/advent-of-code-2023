namespace ScratchCards;

public static class ScratchCardsWinnings
{

    public static async Task<IEnumerable<string>> ReadScratchCard(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    /*
        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        */

    public static int CalculateWinnings(IEnumerable<string> scratchCardLines)
    {
        return scratchCardLines.Select(x =>
            {
                var allNumbers = x.Split(": ")[1];
                var numbers = allNumbers.Split(" | ");
                var winningNumbers = numbers[0].Split(" ").Where(x => !string.IsNullOrEmpty(x));
                var playedNumbers = numbers[1].Split(" ").Where(x => !string.IsNullOrEmpty(x));

                var playedWinningNumbersCount = winningNumbers.Intersect(playedNumbers).Count();

                var result = (int)Math.Pow(2, playedWinningNumbersCount - 1);
                return playedWinningNumbersCount > 0 ? result : 0;
            }
        )
        .Sum();
    }

    public static int CalculateTotalScratchcards(IEnumerable<string> scratchCardLines)
    {
        /*
        [1],
        [2,3,4],[2,3,4],
        [3,4],[3,4],[5,6,7],[4,5,6],[5,6],[5,6]
        */

        return 0;
    }
}
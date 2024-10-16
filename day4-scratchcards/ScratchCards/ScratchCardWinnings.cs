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
        var all = scratchCardLines.Select(TotalWinningNumbers).ToList();

        // winning numbers ->  count cards -> sum
        var array = new int[all.Count];
        for (int i = 0; i < all.Count; i++)
        {
            array[i]++;
            for (int k = 0; k < array[i]; k++)
            {
                var total = all[i];
                for (int j = 1; j <= total; j++)
                {
                    array[i + j]++;
                }
            }

        }

        return array.Sum();
    }

    private static int TotalWinningNumbers(string scratchCardLine)
    {
        var allNumbers = scratchCardLine.Split(": ")[1];
        var numbers = allNumbers.Split(" | ");
        var winningNumbers = numbers[0].Split(" ").Where(x => !string.IsNullOrEmpty(x));
        var playedNumbers = numbers[1].Split(" ").Where(x => !string.IsNullOrEmpty(x));

        return winningNumbers.Intersect(playedNumbers).Count();
    }
}
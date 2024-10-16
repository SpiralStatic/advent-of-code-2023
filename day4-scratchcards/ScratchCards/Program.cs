using ScratchCards;

var scratchCardLines = await ScratchCardsWinnings.ReadScratchCard("./input.txt");

var part1 = ScratchCardsWinnings.CalculateWinnings(scratchCardLines);

Console.WriteLine(part1);

var part2 = ScratchCardsWinnings.CalculateTotalScratchcards(scratchCardLines);

Console.WriteLine(part2);
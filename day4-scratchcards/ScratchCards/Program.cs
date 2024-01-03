using ScratchCards;

var scratchCardLines = await ScratchCardsWinnings.ReadScratchCard("./input.txt");

var result = ScratchCardsWinnings.CalculateWinnings(scratchCardLines);

Console.WriteLine(result);
namespace GearRatios;

public static class EngineFinder
{
    public static async Task<IEnumerable<string>> ReadSchematic(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int FindPartNumberSum(IEnumerable<string> schematic)
    {
        var schematicSize = schematic.First().Length;
        var schematicAsArray = schematic.SelectMany(x => x.ToCharArray()).ToArray();

        var allowedSymbols = new List<char> { '*', '#', '+', '-', '=', '/', '%', '$', '@', '&' };
        var symbols = schematicAsArray
            .Select((character, index) => (character, index))
            .Where((x) => allowedSymbols.Contains(x.character));

        var partNumbers = symbols.Aggregate(0, (agg, symbol) =>
        {
            var positionsToCheck = new List<int> {
                symbol.index - schematicSize + 1, // Top Left
                symbol.index - schematicSize, // Top
                symbol.index - schematicSize - 1, // Top Right
                symbol.index - 1, // Left
                symbol.index + 1, // Right
                symbol.index + schematicSize - 1, // Bottom Left
                symbol.index + schematicSize, // Bottom
                symbol.index + schematicSize + 1, // Bottom Right
            };

            var validPositions = positionsToCheck.Where(x =>
            {
                var character = schematicAsArray[x];
                return x >= 0 && char.IsDigit(character);
            });

            var numbers = validPositions.Select(x =>
            {
                var numberBuilder = new List<(int IndexSum, char Digit)> { (x, schematicAsArray[x]) };

                ReadAdjacentCharacters(x, false, schematicAsArray, numberBuilder); // Read Left

                ReadAdjacentCharacters(x, true, schematicAsArray, numberBuilder); // Read Right

                var indexSum = numberBuilder.Sum(x => x.IndexSum);
                var number = int.Parse(numberBuilder.Select(x => x.Digit).ToArray());

                return (IndexSum: indexSum, Number: number);
            });

            var dedupedNumbers = numbers
                .DistinctBy(x => x.IndexSum)
                .Select(x => x.Number)
                .Sum();

            return agg + dedupedNumbers;
        });

        return partNumbers;
    }

    private static void ReadAdjacentCharacters(int startingIndex, bool direction, char[] schematicAsArray, List<(int, char)> numberBuilder)
    {
        var continueOn = true;
        var nextIndex = startingIndex + (direction ? 1 : -1);
        while (continueOn)
        {
            if (nextIndex >= 0 && nextIndex <= schematicAsArray.Length)
            {
                var nextCharacter = schematicAsArray[nextIndex];
                if (char.IsDigit(nextCharacter))
                {
                    if (direction)
                    {
                        numberBuilder.Add((nextIndex, nextCharacter));
                        nextIndex++;
                    }
                    else
                    {
                        numberBuilder.Insert(0, (nextIndex, nextCharacter));
                        nextIndex--;
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
}
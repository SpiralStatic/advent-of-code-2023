using System.Text;

namespace GearRatios;

public static class EngineFinder
{
    public static async Task<IEnumerable<string>> ReadSchematic(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int ReadSchematic(IEnumerable<string> schematic)
    {
        /*  
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
        */

        var schematicSize = schematic.First().Length;
        var schematicAsArray = schematic.SelectMany(x => x.ToCharArray()).ToArray();

        var allowedSymbols = new List<char> { '*', '#', '+', '-', '=', '/', '%', '$', '@' };
        var symbols = schematicAsArray
            .Select((character, index) => (character, index))
            .Where((x) => allowedSymbols.Contains(x.character));

        var partNumbers = symbols.Aggregate(new List<int>(), (agg, symbol) =>
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
                return x >= 0 && char.IsDigit(character) && char.GetNumericValue(character) != 0;
            }).ToList();

            var numbers = validPositions.Select(x =>
            {
                var numberBuilder = new StringBuilder(schematicAsArray[x].ToString());

                var carryOnLeft = true;
                var left = x - 1;
                while (carryOnLeft)
                {
                    if (left >= 0)
                    {
                        var leftCharacter = schematicAsArray[left];
                        if (char.IsDigit(leftCharacter) && char.GetNumericValue(leftCharacter) != 0)
                        {
                            numberBuilder.Insert(0, leftCharacter);
                            left--;
                        }
                        else
                        {
                            carryOnLeft = false;
                            break;
                        }
                    }
                    else
                    {
                        carryOnLeft = false;
                        break;
                    }
                }

                var carryOnRight = true;
                var right = x + 1;
                while (carryOnRight)
                {
                    if (right <= schematicAsArray.Length)
                    {
                        var rightCharacter = schematicAsArray[right];
                        if (char.IsDigit(rightCharacter) && char.GetNumericValue(rightCharacter) != 0)
                        {
                            numberBuilder.Append(rightCharacter);
                            right++;
                        }
                        else
                        {
                            carryOnRight = false;
                            break;
                        }
                    }
                    else
                    {
                        carryOnRight = false;
                        break;
                    }
                }

                var numberAsString = numberBuilder.ToString();
                return int.Parse(numberAsString);
            }); ;

            agg.AddRange(numbers);

            return agg;
        });

        return partNumbers.Distinct().Sum();
    }
}
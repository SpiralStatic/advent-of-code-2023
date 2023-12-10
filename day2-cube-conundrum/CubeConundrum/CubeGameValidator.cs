namespace CubeConundrum;

public static class CubeGameValidator
{
    public static async Task<IEnumerable<string>> ReadGameRecords(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int GameValidator(IEnumerable<string> records, Bag loadedBag)
    {
        return ParseGameRecords(records)
            .Where(x => x.Bags.All(bag => ValidateGameRecord(bag, loadedBag)))
            .Sum(x => x.Id);
    }

    private static IEnumerable<GameRecord> ParseGameRecords(IEnumerable<string> records)
    {
        // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
        return records.Select((x, index) =>
        {
            var splitOnColon = x.Split(": "); // [Game 1], [3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green]
            var splitOnSemicolon = splitOnColon.Last().Split("; "); // [3 blue, 4 red], [1 red, 2 green, 6 blue], [2 green]
            var bags = splitOnSemicolon.Select(x =>
            {
                var splitOnComma = x.Split(", "); // [3 blue], [4 red]
                var cubes = splitOnComma.Select(x =>
                {
                    return x.Split(" "); // [3], [blue]
                })
                .ToDictionary(x => x[1], x => x[0]);

                var blue = cubes.ContainsKey("blue") ? int.Parse(cubes["blue"]) : 0;
                var green = cubes.ContainsKey("green") ? int.Parse(cubes["green"]) : 0;
                var red = cubes.ContainsKey("red") ? int.Parse(cubes["red"]) : 0;

                return new Bag(blue, green, red);
            });

            return new GameRecord(index + 1, bags);
        });
    }

    private static bool ValidateGameRecord(Bag bag, Bag loadedBag)
    {
        return
            bag.Blue <= loadedBag.Blue &&
            bag.Green <= loadedBag.Green &&
            bag.Red <= loadedBag.Red;
    }
}
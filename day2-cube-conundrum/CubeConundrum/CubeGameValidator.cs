namespace CubeConundrum;

public static class CubeGameValidator
{
    public static async Task<IEnumerable<string>> ReadGameRecords(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int GameValidator(IEnumerable<string> records, Bag bag)
    {
        return 0;
    }
}
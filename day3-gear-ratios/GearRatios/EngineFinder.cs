namespace GearRatios;

public static class EngineFinder
{
    public static async Task<IEnumerable<string>> ReadSchematic(string path)
    {
        return await File.ReadAllLinesAsync(path);
    }

    public static int ReadSchematic(IEnumerable<string> schematic)
    {
        return 0;
    }
}
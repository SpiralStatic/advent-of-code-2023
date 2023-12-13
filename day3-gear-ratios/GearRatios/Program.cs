using GearRatios;

var schematic = await EngineFinder.ReadSchematic("./input.txt");

var partNumbersSum = EngineFinder.FindPartNumberSum(schematic);
Console.WriteLine(partNumbersSum);

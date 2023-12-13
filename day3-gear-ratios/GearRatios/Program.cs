using GearRatios;

var schematic = await EngineFinder.ReadSchematic("./input.txt");

var partNumbersSum = EngineFinder.FindPartNumberSum(schematic);
Console.WriteLine(partNumbersSum);

var gearRatioSum = EngineFinder.CalculateGearRatioSum(schematic);
Console.WriteLine(gearRatioSum);

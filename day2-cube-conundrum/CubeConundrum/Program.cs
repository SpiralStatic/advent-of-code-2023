using CubeConundrum;

var gameRecords = await CubeGameValidator.ReadGameRecords("./input.txt");
var loadedBag = new Bag(14, 13, 12);

var validGameIdsSum = CubeGameValidator.GameValidator(gameRecords, loadedBag);
Console.WriteLine(validGameIdsSum);

var minimumCubesPowerSum = CubeGameValidator.MinimumCubesPower(gameRecords);
Console.WriteLine(minimumCubesPowerSum);
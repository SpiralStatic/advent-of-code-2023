using TrebuchetCalculation;

var calibrationValues = await TrebuchetCalibration.ReadCalibrationDocument("./input.txt");

var overallCalibrationValue = TrebuchetCalibration.CalculateCalibrationValue(calibrationValues);

Console.WriteLine(overallCalibrationValue);
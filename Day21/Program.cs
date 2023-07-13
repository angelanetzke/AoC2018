using Day21;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theDevice = new Device(allLines);
	var result = theDevice.Execute();
	Console.WriteLine($"Part 1: {result}");
}
using Day18;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theArea = new Area(allLines);
	theArea.Iterate(10);
	Console.WriteLine($"Part 1: {theArea.GetResourceValue()}");
}
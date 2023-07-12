using Day19;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theDevice = new Device(allLines);
	var register0 = theDevice.Execute();
	Console.WriteLine($"Part 1: {register0}");
}

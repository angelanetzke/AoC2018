using Day20;

var directions = File.ReadAllLines("input.txt")[0];
Part1(directions);

static void Part1(string allText)
{
	Room.Generate(allText);	
	Console.WriteLine($"Part 1: {Room.GetLongestDistace()}");
}

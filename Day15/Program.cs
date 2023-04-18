using Day15;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theBattlefield = new Battlefield(allLines);
	var isSuccessful = true;
	do
	{
		isSuccessful = theBattlefield.TakeTurn();
	} while (isSuccessful);
	var finalStats = theBattlefield.GetStats();
	Console.WriteLine($"Part 1: {finalStats.Item1 * finalStats.Item2}");
}
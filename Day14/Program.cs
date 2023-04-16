using Day14;

var inputLine = File.ReadAllLines("input.txt")[0];
var iterationCount = int.Parse(inputLine);
Part1(iterationCount);

static void Part1(int iterationCount)
{
	var theBoard = new RecipeBoard(3, 7, iterationCount);
	string? result;
	do
	{
		result = theBoard.NextIteration();
	} while(result == null);
	Console.WriteLine($"Part 1: {result}");
}

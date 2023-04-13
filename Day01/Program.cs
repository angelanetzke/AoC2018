var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

void Part1(string[] allLines)
{
	var total = 0;
	foreach (string thisLine in allLines)
	{
		if (thisLine[0] == '+')
		{
			total += int.Parse(thisLine[1..]);
		}
		else
		{
			total -= int.Parse(thisLine[1..]);
		}
	}
	Console.WriteLine($"Part 1: {total}");
}
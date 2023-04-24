using Day16;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var greaterThan3Count = 0;
	var isLastLineBlank = true;
	Device? nextDevice = null;
	var nextData = new List<string>();
	foreach (string thisLine in allLines)
	{
		if  (thisLine.Length == 0)
		{
			if (isLastLineBlank)
			{
				break;
			}
			nextDevice = new Device(nextData);
			var matchCount = nextDevice.CountMatches();
			greaterThan3Count += matchCount >= 3 ? 1 : 0;
			nextData.Clear();
			isLastLineBlank = true;
		}
		else
		{
			nextData.Add(thisLine);
			isLastLineBlank = false;
		}
	}
	Console.WriteLine($"Part 1: {greaterThan3Count}");
}
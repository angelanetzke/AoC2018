var inputLine = File.ReadAllLines("input.txt")[0];
Part1(inputLine);

static void Part1(string inputLine)
{
	int reactionCount;
	var lastString = inputLine;
	string thisString;
	do 
	{
		reactionCount = 0;
		for (char thisUnit = 'a'; thisUnit <= 'z'; thisUnit++)
		{
			var pair1 = thisUnit.ToString() + char.ToUpper(thisUnit);
			var pair2 = char.ToUpper(thisUnit).ToString() + thisUnit;
			thisString = lastString.Replace(pair1, "");
			thisString = thisString.Replace(pair2, "");
			if (lastString.Length > thisString.Length)
			{
				reactionCount++;
			}
			lastString = thisString;
		}
	} while (reactionCount > 0);
	Console.WriteLine($"Part 1: {lastString.Length}");
}
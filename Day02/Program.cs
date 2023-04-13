var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var twoCount = allLines.Where(x => HasExactlyTwo(x)).Count();
	var threeCount = allLines.Where(x => HasExactlyThree(x)).Count();
	var result = twoCount * threeCount;
	Console.WriteLine($"Part 1: {result}");
}

static bool HasExactlyTwo(string startString)
{
	var lastString = startString;
	string thisString;
	while (lastString.Length > 0)
	{
		thisString = lastString.Replace(lastString[0].ToString(), "");
		if (lastString.Length - thisString.Length == 2)
		{
			return true;
		}
		lastString = thisString;		
	}
	return false;
}

static bool HasExactlyThree(string startString)
{
	var lastString = startString;
	string thisString;
	while (lastString.Length > 0)
	{
		thisString = lastString.Replace(lastString[0].ToString(), "");
		if (lastString.Length - thisString.Length == 3)
		{
			return true;
		}
		lastString = thisString;		
	}
	return false;
}

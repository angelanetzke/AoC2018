var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var solution = new List<char>();
	var nextSteps = new Dictionary<char, List<char>>();
	var requirements = new Dictionary<char, List<char>>();
	foreach (string thisLine in allLines)
	{
		var firstLetter = thisLine[5];
		var secondLetter = thisLine[36];
		if (nextSteps.ContainsKey(firstLetter))
		{
			nextSteps[firstLetter].Add(secondLetter);
		}
		else
		{
			nextSteps[firstLetter] = new List<char>() { secondLetter };
		}
		if (requirements.ContainsKey(secondLetter))
		{
			requirements[secondLetter].Add(firstLetter);
		}
		else
		{
			requirements[secondLetter] = new List<char>() { firstLetter };
		}
	}
	var queue = new HashSet<char>(nextSteps.Keys);
	queue.RemoveWhere(x => requirements.Keys.Contains(x));
	var visited = new HashSet<char>();
	while (queue.Count > 0)
	{
		var current = queue.Min();
		visited.Add(current);
		queue.Remove(current);
		solution.Add(current);
		if (nextSteps.ContainsKey(current))
		{			
			foreach (char thisNextStep in nextSteps[current])
			{
				var requirementsMet = true;
				if (requirements.ContainsKey(thisNextStep))
				{
					foreach (char thisRequirement in requirements[thisNextStep])
					{
						if (!visited.Contains(thisRequirement))
						{
							requirementsMet = false;
						}
					}
				}
				if (!visited.Contains(thisNextStep) && requirementsMet)
				{
					queue.Add(thisNextStep);
				}				
			}
		}
	}	
	Console.WriteLine($"Part 1: {string.Join("", solution)}");
}


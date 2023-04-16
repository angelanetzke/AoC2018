using System.Text;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var spread = new Dictionary<string, char>();
	var plants = new HashSet<int>();
	var nextPlants = new HashSet<int>();
	for (int i = 2; i < allLines.Length; i++)
	{
		var inputString = allLines[i].Split(" => ")[0];
		var outputChar = allLines[i].Split(" => ")[1][0];
		spread[inputString] = outputChar;
	}
	for (int i = 15; i < allLines[0].Length; i++)
	{
		if (allLines[0][i] == '#')
		{
			plants.Add(i - 15);
		}
	}
	var generationCount = 20;
	var builder = new StringBuilder();
	for (int i = 1; i <= generationCount; i++)
	{
		nextPlants.Clear();
		for (int plantNumber = plants.Min() - 2; plantNumber <= plants.Max() + 2; plantNumber++)
		{
			builder.Clear();
			for (int neighbor = -2; neighbor <= 2; neighbor++)
			{
				if (plants.Contains(plantNumber + neighbor))
				{
					builder.Append('#');
				}
				else
				{
					builder.Append('.');
				}
			}
			if (spread.ContainsKey(builder.ToString()) && spread[builder.ToString()] == '#')
			{
				nextPlants.Add(plantNumber);
			}
		}
		plants = new HashSet<int>(nextPlants);
	}
	var plantSum = plants.Sum();
	Console.WriteLine($"Part 1: {plantSum}");
}

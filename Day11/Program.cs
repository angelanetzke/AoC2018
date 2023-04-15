var inputLine = File.ReadAllLines("input.txt")[0];
Part1(inputLine);

static void Part1(string inputLine)
{
	var serialNumber = int.Parse(inputLine);
	var highestPowerLevel = int.MinValue;
	var highestX = -1;
	var highestY = -1;
	for (int x = 1; x <= 298; x++)
	{
		for (int y = 1; y <= 298; y++)
		{
			var totalPowerLevel = 0;
			for (int deltaX = 0; deltaX <= 2; deltaX++)
			{
				for (int deltaY = 0; deltaY <= 2; deltaY++)
				{
					totalPowerLevel += GetPowerLevel(x + deltaX, y + deltaY, serialNumber);
				}
			}
			if (totalPowerLevel > highestPowerLevel)
			{
				highestPowerLevel = totalPowerLevel;
				highestX = x;
				highestY = y;
			}
		}
	}
	Console.WriteLine($"Part 1: {highestX},{highestY}");
}

static int GetPowerLevel(int x, int y, int serialNumber)
{
	return ((((x + 10) * y + serialNumber) * (x + 10)) / 100) % 10 - 5;
}
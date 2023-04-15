using Day08;

var inputLine = File.ReadAllLines("input.txt")[0];
Part1(inputLine);

static void Part1(string inputLine)
{
	Node.SetValues(inputLine);
	var root = new Node();
	var sum = root.GetMetadataSum();
	Console.WriteLine($"Part 1: {sum}");
}


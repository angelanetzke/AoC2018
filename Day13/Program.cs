using Day13;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] map)
{
	var cartList = new List<Cart>();
	var directionChars = new List<char> { '^', '>', 'v', '<' };
	for (int row = 0; row < map.Length; row++)
	{
		for (int column = 0; column < map[row].Length; column++)
		{
			if (directionChars.Contains(map[row][column]))
			{
				cartList.Add(new Cart(column, row, map[row][column]));
			}
		}
	}
	var crashFound = false;
	var crashX = -1;
	var crashY = -1;
	while(!crashFound)
	{
		cartList = cartList.OrderBy(x => x.GetLocationString()).ToList();
		foreach(Cart thisCart in cartList)
		{
			thisCart.Update(map);
			var cartsHere = cartList.Where(x => x.GetLocationString() == thisCart.GetLocationString());
			if (cartsHere.Count() > 1)
			{
				crashFound = true;
				crashX = thisCart.GetX();
				crashY = thisCart.GetY();
				break;
			}
		}
	}
	Console.WriteLine($"Part 1: {crashX},{crashY}");
}
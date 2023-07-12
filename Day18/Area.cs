namespace Day18
{
	internal class Area
	{
		private enum State { Ground, Trees, Lumberyard }
		private Dictionary<(int, int), State> currentStates = new ();
		private readonly int height;
		private readonly int width;

		public Area(string[] allLines)
		{
			height = allLines.Length;
			width = allLines[0].Length;
			for (int row = 0; row < allLines.Length; row++)
			{
				for (int column = 0; column < allLines[row].Length; column++)
				{
					switch (allLines[row][column])
					{
						case '.':
							currentStates[(row, column)] = State.Ground;
							break;
						case '|':
							currentStates[(row, column)] = State.Trees;
							break;
						case '#':
							currentStates[(row, column)] = State.Lumberyard;
							break;
					}
				}
			}
		}

		public void Iterate()
		{
			var temp = new Dictionary<(int, int), State>();
			for (int row = 0; row < height; row++)
			{
				for (int column = 0; column < width; column++)
				{
					var neighborList = GetNeighborStates((row, column));
					switch (currentStates[(row, column)])
					{
						case State.Ground:
							temp[(row, column)] 
								= neighborList.Count(x => x == State.Trees) >= 3 
								? State.Trees : State.Ground;
							break;
						case State.Trees:
							temp[(row, column)] 
								= neighborList.Count(x => x == State.Lumberyard) >= 3 
								? State.Lumberyard : State.Trees;
							break;
						case State.Lumberyard:
							temp[(row, column)] 
								= neighborList.Count(x => x == State.Lumberyard) >= 1 
								&& neighborList.Count(x => x == State.Trees) >= 1
								? State.Lumberyard : State.Ground;
							break;
					}
				}
			}
			currentStates = temp;
		}

		public void Iterate(int times)
		{
			for (int i = 1; i <= times; i++)
			{
				Iterate();
			}
		}

		private List<State> GetNeighborStates((int, int) location)
		{
			var neighborList = new List<State>();
			for (int deltaRow = -1; deltaRow <= 1; deltaRow++)
			{
				for (int deltaColumn = -1; deltaColumn <= 1; deltaColumn++)
				{
					if (deltaRow == 0 && deltaColumn == 0)
					{
						continue;
					}
					if (currentStates.ContainsKey((location.Item1 + deltaRow, location.Item2 + deltaColumn)))
					{
						neighborList.Add(currentStates[(location.Item1 + deltaRow, location.Item2 + deltaColumn)]);
					}
				}
			}
			return neighborList;
		}

		public int GetResourceValue()
		{
			return currentStates.Values.Count(x => x == State.Trees) * currentStates.Values.Count(x => x == State.Lumberyard);
		}

	}
}
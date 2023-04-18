using System.Text;

namespace Day15
{
	internal class Battlefield
	{
		private readonly HashSet<(int, int)> spaces = new ();
		private List<Warrior> warriorList = new ();
		private int completeTurnCount = 0;

		public Battlefield(string[] allLines)
		{
			for (int row = 0; row < allLines.Length; row++)
			{
				for (int column = 0; column < allLines[row].Length; column++)
				{
					if (allLines[row][column] == '.')
					{
						spaces.Add((row, column));
					}
					if (allLines[row][column] == 'E' || allLines[row][column] == 'G')
					{
						warriorList.Add(new Warrior(row, column, allLines[row][column]));
						spaces.Add((row, column));
					}
				}
			}
		}

		public bool TakeTurn()
		{
			warriorList = warriorList.OrderBy(w => w.GetLocation()).ToList();
			foreach (Warrior thisWarrior in warriorList)
			{
				if (thisWarrior.isRemoved)
				{
					continue;
				}
				if (!thisWarrior.TakeTurn(warriorList, spaces))
				{
					return false;
				}
			}
			warriorList = warriorList.Where(w => !w.isRemoved).ToList();
			completeTurnCount++;
			return true;			
		}

		public (int, int) GetStats()
		{
			var totalHP = warriorList.Where(w => !w.isRemoved).Select(w => w.GetHP()).Sum();
			return (completeTurnCount, totalHP);
		}

	}
}
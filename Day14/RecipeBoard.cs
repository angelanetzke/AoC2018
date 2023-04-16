namespace Day14
{
	internal class RecipeBoard
	{
		private Recipe head;
		private Recipe tail;
		private Recipe elf1;
		private Recipe elf2;
		private int size;
		private int iterationCount;
		private List<int> lastTen = new ();

		public RecipeBoard(int first, int second, int iterationCount)
		{
			head = new Recipe(first);
			tail = new Recipe(second);
			elf1 = head;
			elf2 = tail;
			head.previous = tail;
			head.next = tail;
			tail.previous = head;
			tail.next = head;
			size = 2;
			this.iterationCount = iterationCount;
		}

		public string? NextIteration()
		{
			List<int> recipesToAdd;
			var lastRecipeSum = elf1.score + elf2.score;
			if (lastRecipeSum >= 10)
			{
				recipesToAdd = new List<int>() { lastRecipeSum / 10, lastRecipeSum % 10 };
			}
			else
			{
				recipesToAdd = new List<int>() { lastRecipeSum };
			}
			foreach (int thisNewRecipeScore in recipesToAdd)
			{
				var newRecipe = new Recipe(thisNewRecipeScore);
				tail.next = newRecipe;
				newRecipe.previous = tail;
				newRecipe.next = head;
				tail = newRecipe;
				size++;
				if (size > iterationCount)
				{
					lastTen.Add(thisNewRecipeScore);
					if (lastTen.Count == 10)
					{
						return string.Join("", lastTen);
					}
				}
			}
			var currentElf1Score = elf1.score;
			var currentElf2Score = elf2.score;
			for (int i = 1; i <= currentElf1Score + 1; i++)
			{
				elf1 = elf1.next;
			}
			for (int i = 1; i <= currentElf2Score + 1; i++)
			{
				elf2 = elf2.next;
			}
			return null;
		}
		
		private class Recipe
		{
			public int score {get; }
			public Recipe previous {set; get; }
			public Recipe next {set; get; }

			public Recipe(int score)
			{
				this.score = score;
				previous = this;
				next = this;
			}

		}
	}
}
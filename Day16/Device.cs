using System.Text.RegularExpressions;

namespace Day16
{
	internal class Device
	{
		private int[]  initialRegisters;
		private int[]  finalRegisters;
		private int[] instruction;

		public Device (List<string> inputStrings)
		{
			var splitStart = inputStrings[0].IndexOf('[') + 1;
			var initialData = inputStrings[0].Substring(splitStart, inputStrings[0].Length - (splitStart + 1));
			initialRegisters = initialData.Split(", ").Select(x => int.Parse(x)).ToArray();
			instruction = inputStrings[1].Split(' ').Select(x => int.Parse(x)).ToArray();
			var finalData = inputStrings[2].Substring(splitStart, inputStrings[2].Length - (splitStart + 1));
			finalRegisters = finalData.Split(", ").Select(x => int.Parse(x)).ToArray();		
		}

		public int CountMatches()
		{
			var matchCount = 0;
			matchCount += finalRegisters.SequenceEqual<int>(Addr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Addi(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Mulr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Muli(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Banr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Bani(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Borr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Bori(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Setr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Seti(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Gtir(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Gtri(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Gtrr(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Eqir(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Eqri(initialRegisters, instruction)) ? 1 : 0;
			matchCount += finalRegisters.SequenceEqual<int>(Eqrr(initialRegisters, instruction)) ? 1 : 0;
			return matchCount;
		}

		private static int[] Addr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a + b;
			return result;
		}

		private static int[] Addi(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a + b;
			return result;
		}

		private static int[] Mulr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a * b;
			return result;
		}

		private static int[] Muli(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a * b;
			return result;
		}

		private static int[] Banr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a & b;
			return result;
		}

		private static int[] Bani(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a & b;
			return result;
		}
		
		private static int[] Borr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a | b;
			return result;
		}

		private static int[] Bori(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a | b;
			return result;
		}

		private static int[] Setr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			result[instruction[3]] = register[instruction[1]];
			return result;
		}

		private static int[] Seti(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			result[instruction[3]] = instruction[1];
			return result;
		}

		private static int[] Gtir(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = instruction[1];
			var b = register[instruction[2]];
			result[instruction[3]] = a > b ? 1 : 0;
			return result;
		}

		private static int[] Gtri(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a > b ? 1 : 0;
			return result;
		}

		private static int[] Gtrr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a > b ? 1 : 0;
			return result;
		}

		private static int[] Eqir(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = instruction[1];
			var b = register[instruction[2]];
			result[instruction[3]] = a == b ? 1 : 0;
			return result;
		}

		private static int[] Eqri(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = instruction[2];
			result[instruction[3]] = a == b ? 1 : 0;
			return result;
		}

		private static int[] Eqrr(int[] register, int[] instruction)
		{
			int[] result = new int[register.Length];
			Array.Copy(register, result, register.Length);
			var a = register[instruction[1]];
			var b = register[instruction[2]];
			result[instruction[3]] = a == b ? 1 : 0;
			return result;
		}

	}
}
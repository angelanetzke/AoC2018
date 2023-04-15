﻿using Day09;

var inputLine = File.ReadAllLines("input.txt")[0];
Part1(inputLine);

static void Part1(string inputLine)
{
	var playerCount = int.Parse(inputLine.Split(' ')[0]);
	var lastMarble = int.Parse(inputLine.Split(' ')[6]);
	var playerScores = Enumerable.Repeat(0, playerCount).ToArray();
	var theCircle = new MarbleCirle();
	for (int i = 1; i <= lastMarble; i++)
	{
		var nextScore = theCircle.PlayNext();
		playerScores[i % playerCount] += nextScore;
	}
	var highScore = playerScores.Max();
	Console.WriteLine($"Part 1: {highScore}");
}

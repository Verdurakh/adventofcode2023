namespace AdventOfCode2023.Day2;

public class Day2Step2
{
    private static (string color, int amount) _red = ("red", 0);
    private static (string color, int amount) _green = ("green", 0);
    private static (string color, int amount) _blue = ("blue", 0);

    public static void Run()
    {
        var lines = File.ReadAllLines("Day2/input.txt").ToList();
        var sum = 0;
        foreach (var line in lines)
        {
            var game = GetMinNumberOfBlocks(line);
            if (game.possible)
                sum += game.id;
        }

        Console.WriteLine("Sum: " + sum);
    }

    private static (bool possible, int id) GetMinNumberOfBlocks(string line)
    {
        ResetDice();
        //Console.WriteLine(line);
        var rawLine = line.Replace("Game ", "");
        var game = int.Parse(rawLine[..rawLine.IndexOf(":", StringComparison.Ordinal)]);
        var grabs = rawLine[(rawLine.IndexOf(':') + 1)..].Split(";");
        var isValid = true;
        foreach (var grab in grabs)
        {
            var individualGrab = grab.Trim().Split(",");
            foreach (var s in individualGrab)
            {
                var split = s.Trim().Split(" ");
                var color = split[1];
                var amount = int.Parse(split[0]);
                SetMinNumber(color, amount, isValid);
            }
        }

        // Console.WriteLine($"{Red.amount} {Green.amount} {Blue.amount}");
        return (isValid, _red.amount * _green.amount * _blue.amount);
    }

    private static void ResetDice()
    {
        _red = ("red", 0);
        _green = ("green", 0);
        _blue = ("blue", 0);
    }

    private static void SetMinNumber(string color, int amount, bool isValid)
    {
        if (color == _red.color)
        {
            if (amount > _red.amount)
            {
                _red.amount = amount;
            }
        }
        else if (color == _green.color)
        {
            if (amount > _green.amount)
            {
                _green.amount = amount;
            }
        }
        else if (color == _blue.color)
        {
            if (amount > _blue.amount)
            {
                _blue.amount = amount;
            }
        }
    }
}
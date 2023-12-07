namespace AdventOfCode2023.Day2;

public class Day2Step1
{
    private static (string color,int amount) _red= ("red", 12);
    private static (string color,int amount) _green= ("green", 13);
    private static (string color,int amount) _blue= ("blue", 14);
    public static void Run()
    {
        var lines = File.ReadAllLines("Day2/input.txt").ToList();
        var sum = 0;
        foreach (var line in lines)
        {
            var game = IsGamePossible(line);
            if(game.possible)
                sum += game.id;
        }

        Console.WriteLine("Sum: " + sum);
    }
    
    private static (bool possible, int id) IsGamePossible(string line)
    {
        var rawLine = line.Replace("Game ", "");
        var game= int.Parse(rawLine[..rawLine.IndexOf(":", StringComparison.Ordinal)]);
        var grabs = rawLine[(rawLine.IndexOf(':')+1)..].Split(";");
        var isValid = true;
        foreach (var grab in grabs)
        {
            var individualGrab = grab.Trim().Split(",");
            foreach (var s in individualGrab)
            {
                var split= s.Trim().Split(" ");
                var color = split[1];
                var amount = int.Parse(split[0]);
                isValid = IsColorValid(color, amount, isValid);
            }
       
        }


        return (isValid, game);
    }

    private static bool IsColorValid(string color, int amount, bool isValid)
    {
        if (color == _red.color)
        {
            if (amount > _red.amount)
            {
                isValid = false;
            }
        }
        else if (color == _green.color)
        {
            if (amount > _green.amount)
            {
                isValid = false;
            }
        }
        else if (color == _blue.color)
        {
            if (amount > _blue.amount)
            {
                isValid = false;
            }
        }

        return isValid;
    }
}
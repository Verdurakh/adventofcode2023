namespace AdventOfCode2023.Day1;

public class Day1Step1
{
    public static void Run()
    {
        var lines = File.ReadAllLines("Day1/input.txt").ToList();
        var sum = 0;
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            var val = ParseStringToInt(line);
            Console.WriteLine("Parsed: " + val);
            sum += val;
        }

        Console.WriteLine("Sum: " + sum);
    }

    private static int ParseStringToInt(string input)
    {
        var firstDigit = FindFirstDigit(input);
        var lastDigit = FindFirstDigit(string.Join("", input.Reverse().ToList()));
        return int.Parse(firstDigit + "" + lastDigit);
    }


    private static char FindFirstDigit(string input)
    {
        foreach (var character in input)
        {
            if (int.TryParse(character.ToString(), out var digit))
                return character;
        }

        throw new Exception("No digit found");
    }
}
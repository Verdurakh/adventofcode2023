namespace AdventOfCode2023.Day1;

public class Day1Step2
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
        var lastDigit = FindLastDigit(input);
        return int.Parse(firstDigit + "" + lastDigit);
    }

    private static char FindLastDigit(string input)
    {
        int i = 0;
        char foundDigit = ' ';
        foreach (var character in input)
        {
            if (StartsWithNumber(i, input, out var digit))
                foundDigit = digit;

            if (int.TryParse(character.ToString(), out var _))
                foundDigit = character;
            i++;
        }

        return foundDigit;
    }

    private static char FindFirstDigit(string input)
    {
        int i = 0;
        foreach (var character in input)
        {
            if (StartsWithNumber(i, input, out var digit))
                return digit;

            if (int.TryParse(character.ToString(), out var _))
                return character;
            i++;
        }

        throw new Exception("No digit found");
    }

    private static bool StartsWithNumber(int i, string input, out char result)
    {
        result = ' ';
        foreach (var listOfNumber in _listOfNumbers)
        {
            if (input.Substring(i).StartsWith(listOfNumber.number))
            {
                result = listOfNumber.digit;
                return true;
            }
        }

        return false;
    }

    private static List<(string number, char digit)> _listOfNumbers = new()
    {
        ("one", '1'),
        ("two", '2'),
        ("three", '3'),
        ("four", '4'),
        ("five", '5'),
        ("six", '6'),
        ("seven", '7'),
        ("eight", '8'),
        ("nine", '9')
    };
}
namespace ManualRadicalCalculation;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input:     ");

        string input = null!;
        //input = "625";
        if (input == null) input = Console.ReadLine() ?? throw new ArgumentNullException(nameof(input));
        else Console.WriteLine("{0}", input);

        Console.Write("Extra 0's: ");
        int extraZeroes = -1;
        //extraZeroes = 50;
        if(extraZeroes < 0) extraZeroes = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(extraZeroes)));
        else Console.WriteLine("{0}", extraZeroes);

        if (extraZeroes > 0)
        {
            if (!input.Contains('.')) input += '.';
            input += new string('0', Ceiling(extraZeroes, 2));
        }

        double factor = 1;

        if(input.Contains('.'))
        {
            int index = input.IndexOf('.');
            string sub = input.Substring( index + 1);
            double rounded = Round(sub.Length, 2);
            factor = (double)Math.Pow(10, rounded / 2);
            input = input.Remove(index, 1);
        }

        string[] groups = MakeGroups(input);
        int groupIndex = 0;

        double ergebnis, divisor, ans, group, firstSquare, division, subtrahend;
        string groupStr;

        ergebnis = 0;

        groupStr = groups[groupIndex];
        group = int.Parse(groupStr);
        firstSquare = GetClosestStartingRadical((double)group);
        ergebnis = ergebnis * 10 + (int)Math.Sqrt((double)firstSquare);
        ans = group - firstSquare;
        groupIndex++;

        while (groupIndex < groups.Length)
        {
            groupStr = groups[groupIndex];
            group = int.Parse(groupStr[0].ToString());
            ans = ans * 10 + group;
            divisor = ergebnis * 2;
            
            division = (int)(ans / divisor);
            if (division > 9) division = 9;
            
            while ((divisor * 10 + division) * division > (ans * 10 + int.Parse(groupStr[1].ToString())))
            {
                division--;
            }

            ergebnis = ergebnis * 10 + division;

            subtrahend = (divisor * 10 + division) * division;
            ans = ans * 10 + int.Parse(groupStr[1].ToString());
            ans = ans - subtrahend;
            groupIndex++;
        }

        ergebnis /= factor;

        Console.WriteLine("Result:    {0}", ergebnis);
        Console.WriteLine("Actual:    {0}", (double)Math.Sqrt(double.Parse(input)) / factor);
        Console.WriteLine();

        Main(args);
    }

    private static string[] MakeGroups(string input)
    {
        int i = 0;
        string[] inputSplit = input.Split('.');
        string inputInteger = inputSplit[0];
        string inputdouble = "";
        
        if (inputSplit.Length > 1)
        {
            inputdouble = inputSplit[1];

            if(inputdouble.Length % 2 == 1)
            {
                inputdouble += "0";
            }
        }

        List<string> groups = new();
        
        if (inputInteger.Length % 2 == 1)
        {
            i = 1;
            groups.Add(inputInteger[0].ToString());
        }

        for(; i < inputInteger.Length; i += 2)
        {
            groups.Add(inputInteger[i].ToString() + inputInteger[i + 1].ToString());
        }

        if(inputdouble.Length > 0)
        {
            groups.Add(".");
        }

        for(i = 0; i < inputdouble.Length; i += 2)
        {
            groups.Add(inputdouble[i].ToString() + inputdouble[i + 1].ToString());
        }

        return groups.ToArray();
    }

    private static int GetClosestStartingRadical(double group)
    {
        return group switch
        {
            < 4 => 1,
            < 9 => 4,
            < 16 => 9,
            < 25 => 16,
            < 36 => 25,
            < 49 => 36,
            < 64 => 49,
            < 81 => 64,
            >= 81 => 81
        };
    }

    private static int Round(double value, double step)
    {
        return (int)(Math.Round(value / step, 0) * step);
    }

    private static int Ceiling(double value, double step)
    {
        return (int)(Math.Ceiling(value / step) * step);
    }
}
using System.Numerics;

namespace ManualRadicalCalculation;

public class ManualRadicalFinder
{
    private string[] groups = null!;
    private int groupIndex, firstSquare;
    private double ergebnis, divisor, ans, group, division, subtrahend;
    private string groupStr = null!;

    public double Process(string input)
    {
        groups = MakeGroups(input);
        groupIndex = 0;

        ProcessFirstRadical();

        while (groupIndex < groups.Length)
        {
            ProcessNextGroup();
        }

        return ergebnis;
    }

    private void ProcessFirstRadical()
    {
        ergebnis = 0;
        groupStr = groups[groupIndex];
        group = int.Parse(groupStr);
        firstSquare = GetClosestStartingRadical(group);
        ergebnis = ergebnis * 10 + GetPerfectSqrt(firstSquare);
        ans = group - firstSquare;
        groupIndex++;
    }

    private void ProcessNextGroup()
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

    private string[] MakeGroups(string input)
    {
        int i = 0;
        string[] inputSplit = input.Split('.');
        string inputInteger = inputSplit[0];
        string inputdouble = "";

        if (inputSplit.Length > 1)
        {
            inputdouble = inputSplit[1];

            if (inputdouble.Length % 2 == 1)
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

        for (; i < inputInteger.Length; i += 2)
        {
            groups.Add(inputInteger[i].ToString() + inputInteger[i + 1].ToString());
        }

        if (inputdouble.Length > 0)
        {
            groups.Add(".");
        }

        for (i = 0; i < inputdouble.Length; i += 2)
        {
            groups.Add(inputdouble[i].ToString() + inputdouble[i + 1].ToString());
        }

        return groups.ToArray();
    }

    private int GetClosestStartingRadical(double group)
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
            >= 81 => 81,
            _ => throw new NotImplementedException("this case should not occur")
        };
    }

    private int GetPerfectSqrt(int square)
    {
        return square switch
        {
            1 => 1,
            4 => 2,
            9 => 3,
            16 => 4,
            25 => 5,
            36 => 6,
            49 => 7,
            64 => 8,
            81 => 9,
            _ => throw new NotImplementedException("this case should not occur")
        };
    }
}

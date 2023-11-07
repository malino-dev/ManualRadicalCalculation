using System.Runtime.InteropServices.Marshalling;

namespace ManualRadicalCalculation;

internal class Program
{
    static string input = null!;
    static int extraZeroes = 100;
    static double factor = 1.0;

    static void Main(string[] args)
    {
        ReadInputs();
        PreProcess();

        RadicalFinder finder = new();
        double result = finder.Process(input);
        Console.WriteLine("Output:    {0}", result / factor);
        Console.WriteLine("Actual:    {0}", Math.Sqrt(double.Parse(input)) / factor);
        Console.WriteLine();

        Main(args);
    }

    private static void ReadInputs()
    {
        Console.Write("Input:     ");
        input = Console.ReadLine() ?? throw new ArgumentNullException(nameof(input));

        Console.Write("Extra 0's: ");
        //extraZeroes = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(extraZeroes)));
        Console.WriteLine();
    }

    private static void PreProcess()
    {
        if (extraZeroes > 0)
        {
            if (!input.Contains('.')) input += '.';
            input += new string('0', Ceiling(extraZeroes, 2));
        }

        factor = 1;

        if (input.Contains('.'))
        {
            int index = input.IndexOf('.');
            string sub = input.Substring(index + 1);
            double rounded = Round(sub.Length, 2);
            factor = Math.Pow(10, rounded / 2);
            input = input.Remove(index, 1);
        }
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
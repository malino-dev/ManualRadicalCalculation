namespace ManualRadicalCalculation;

internal class Program
{
    static string initialInput = null!;
    static string preprocessedInput = null!;
    static int extraZeroes = 100;
    static int babylonIterations = 50;
    static double babylonStart = 1.0;
    static double factor = 1.0;

    static ManualRadicalFinder manualFinder = new();
    static BabylonRadicalFinder babylonFinder = new();
    static QuakeRadicalFinder quakeFinder = new();

    static void Main(string[] args)
    {
        ReadInputs();
        PreProcess();

        double dInput = double.Parse(initialInput);

        Console.WriteLine(Fill("Output: ") + "{0}", 
            manualFinder.Process(preprocessedInput) / factor);
        Console.WriteLine(Fill("Babylon: ") + "{0}", 
            babylonFinder.Process(dInput, babylonFinder.FindStart(dInput), babylonIterations));
        Console.WriteLine(Fill("Quake: ") + "{0}",
            quakeFinder.Process(dInput));
        Console.WriteLine(Fill("Actual: ") + "{0}", 
            Math.Sqrt(double.Parse(initialInput)));
        Console.WriteLine();

        Main(args);
    }

    private static void ReadInputs()
    {
        Console.Write(Fill("Input:      "));
        initialInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(initialInput));

        Console.Write(Fill("Extra 0's:  "));
        //extraZeroes = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(extraZeroes)));
        Console.WriteLine(extraZeroes);

        Console.Write(Fill("Babylon Iterations: "));
        //iterations = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(iterations)));
        Console.WriteLine(babylonIterations);

        Console.Write(Fill("Babylon Start: "));
        //babylonStart = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(babylonStart)));
        Console.WriteLine(babylonStart);
    }

    private static string Fill(string v)
    {
        while (v.Length < 20)
            v += ' ';

        return v;
    }

    private static void PreProcess()
    {
        preprocessedInput = initialInput;

        if (extraZeroes > 0)
        {
            if (!preprocessedInput.Contains('.')) preprocessedInput += '.';
            preprocessedInput += new string('0', Ceiling(extraZeroes, 2));
        }

        factor = 1;

        if (preprocessedInput.Contains('.'))
        {
            int index = preprocessedInput.IndexOf('.');
            string sub = preprocessedInput.Substring(index + 1);
            double rounded = Round(sub.Length, 2);
            factor = Math.Pow(10, rounded / 2);
            preprocessedInput = preprocessedInput.Remove(index, 1);
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
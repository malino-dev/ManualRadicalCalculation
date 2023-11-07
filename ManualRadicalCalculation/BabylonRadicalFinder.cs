namespace ManualRadicalCalculation;

public class BabylonRadicalFinder
{
    public double FindStart(double a)
    {
        int i = 1;

        while(i * i < a)
        {
            i++;
        }

        return i;
    }

    public double Process(double a, double startX, int iterations = 10)
    {
        /*
         * Function:
         * x^2 - a = 0
         * 
         * Newton:
         * x_n+1 = x_n - (f(x_n) / f'(x_n))
         */

        double x = startX;

        double f(double x1) => (x1 * x1) - a;
        double f_(double x1) => 2 * x1;

        for (int i = 0; i < iterations; i++)
        {
            x = x - (f(x) / f_(x));
        }

        return x < 0 ? -x : (x == 0 ? 0 : x);
    }
}

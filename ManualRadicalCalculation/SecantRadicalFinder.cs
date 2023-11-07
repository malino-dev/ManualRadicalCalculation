namespace ManualRadicalCalculation;

public class SecantRadicalFinder
{
    public (double x1, double x2) FindStart(double a)
    {
        double x1 = (a + 1.0) / 2.0;
        double x2 = (a - 1.0) / 2.0;
        return (x1, x2);
    }

    public double Process(double a, double x1, double x2, int iterations = 10)
    {
        /*
         * Function:
         * x^2 - a = 0
         * 
         * Secant method:
         * x_n+1 = x_n - (f(x_n) / f'(x_n))
         */

        double f(double x) => (x * x) - a;
        double g(double x1, double x2) => x2 - f(x2) * (x2 - x1) / (f(x2) - f(x1));

        for (int i = 0; i < iterations; i++)
        {
            double x = g(x1, x2);
            double half = (x1 + x2) / 2.0;
            
            if (x > x1 && x < half) x1 = x;
            else x2 = x;
        }

        return x2;
    }
}

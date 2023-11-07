namespace ManualRadicalCalculation;

public class BabylonRadicalFinder
{
    public double FindStart(double a)
    {
        return (a + 1.0) / 2.0;

        /*int i = 1;

        while(i * i < a)
        {
            i++;
        }

        return i;*/
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

        //double f(double x) => (x * x) - a;
        //double f_(double x) => 2 * x;
        //double g(double x) => x - f(x) / f_(x);

        // credits: https://de.wikipedia.org/wiki/Newtonverfahren#Erstes_Beispiel
        // reason: less divisions (only 1)
        double invA = 1 / a;
        double g(double x) => 0.5 * x * (3.0 - invA * (x * x));

        double x = startX;

        for (int i = 0; i < iterations; i++)
        {
            x = g(x);
        }

        return x < 0 ? -x : (x == 0 ? 0 : x); // extra ternary so we don't get mixed -0/+0.
    }
}

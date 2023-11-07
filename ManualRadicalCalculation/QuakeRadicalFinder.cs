namespace ManualRadicalCalculation;

public class QuakeRadicalFinder
{
    public float Process(float x)
    {
        float xhalf = 0.5f * x;
        int i = BitConverter.SingleToInt32Bits(x);
        i = 0x5f375a86 - (i >> 1); // 0x5f3759df
        x = BitConverter.Int32BitsToSingle(i);
        x = x * (1.5f - xhalf * x * x);
        return 1.0f / x;
    }

    public double Process(double x)
    {
        double xhalf = 0.5 * x;
        long i = BitConverter.DoubleToInt64Bits(x);
        i = 0x5fe6eb50c7b537a9 - (i >> 1); // 0x5FE6EC85E7DE30DA
        x = BitConverter.Int64BitsToDouble(i);
        x = x * (1.5 - xhalf * x * x);
        return 1.0 / x;
    }
}

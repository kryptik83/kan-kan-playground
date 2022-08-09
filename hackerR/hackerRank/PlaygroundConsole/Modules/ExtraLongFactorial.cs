using System.Numerics;

namespace PlaygroundConsole.Modules;

public static class MyMath
{
    public static BigInteger ExtraLongFactorial(int n)
    {
        if (n is 1 or 0)
            return BigInteger.One;
        else
            return n * ExtraLongFactorial(n - 1);
    }
}
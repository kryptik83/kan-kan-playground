namespace PlaygroundConsole.Practice.AlgoDaily;

public static class SumAllPrimes
{
    public static int Calculate(int n)
    {
        if (n <= 1) return 0;
        
        var sum = 0;
        for (var j = 2; j <= n; j++) 
            sum += IsPrime(j) ? j : 0;

        return sum;
    }

    public static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n is 2 or 3) return true;
        if (n % 2 == 0) return false;
        if (n % 3 == 0) return false;

        for (var i = 3; i <= n / 2; i++)
        {
            if (n % i == 0)
                return n == i;
        }

        return true;
    }
}
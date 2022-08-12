namespace PlaygroundConsole;

public static class SumDigits
{
    public static int Compute(int num)
    {
        if (num < 10) return num;

        var sum = 0;
        while (num > 0)
        {
            var rem = num % 10;
            sum += rem;
            num = (num - rem) / 10;
        }

        return Compute(sum);
    }
}
namespace PlaygroundConsole.Practice.AlgoDaily;

public static class FibonacciSequence
{
    public static int GetStack(int number)
    {
        if (number <= 1) return 1;

        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(1);

        for (var j = 2; j <= number; j++)
        {
            var item1 = stack.Pop();
            var item2 = stack.Pop();
            stack.Push(item1);
            stack.Push(item1 + item2);
        }

        return stack.Pop();
    }
    
    public static int GetArray(int number)
    {
        if (number <= 1) return 1;
        
        int[] sequence = new int[number + 1];
        sequence[0] = 1;
        sequence[1] = 1;

        for (var j = 2; j < sequence.Length; j++)
            sequence[j] = sequence[j - 1] + sequence[j - 2];

        return sequence[number];
    }

    public static int GetRecursion(int number)
    {
        #region local function

        int Fib(int n)
        {
            if (n <= 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }

        #endregion

        return Fib(number);
    }
}
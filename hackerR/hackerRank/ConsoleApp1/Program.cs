using ConsoleApp1.Playground;

namespace ConsoleApp1 // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var @string = string.Format("Hello Vijit");
            
            var dict = @string.Select(a => a)
                .GroupBy(a => a)
                .Select(a => new {a.Key, c = a.Count()})
                .ToDictionary(a => a.Key, a => a.c);
            
            
            
            Console.WriteLine(@string);
            new StringInterpolation().Write();
            
            Console.ReadKey();
            
            var c = new InheritedFromAbstract();
            var newVar = c.GetIdentifier();
            Console.WriteLine(newVar);
            Console.ReadKey();

            var a = Math.Pow(10, 2);
            var abc = getHeaviestPackage(new List<int>()
            {
                30,15,14
            });

            Console.WriteLine(abc);
            return;
        }


        public static long getHeaviestPackage(List<int> packageWeights)
        {
            var stack = new Stack<int>();
            long weight = 0;
            packageWeights.Reverse();
            foreach(var item in packageWeights)
                stack.Push(item);

            var newStack = new Stack<int>();

            if (packageWeights.Count == 1)
                return (long)packageWeights.First();

            var stackCount = stack.Count;
            int idx =1;
            var a = stack.Pop();
            idx++;
            while(idx <= stackCount){
                var b = stack.Pop();
                if (a < b)
                {
                    var sum = a + b;
                    stack.Push(sum);

                    while(newStack.Count > 0)
                        stack.Push(newStack.Pop());

                    stackCount = stack.Count;
                    a  = stack.Pop();
                    Console.WriteLine($"a ==> {a}; {string.Join("--", stack)}");
                    idx = 1;
                }
                else
                {
                    newStack.Push(a);
                    a = b;
                    idx++;
                }
            }

            return (long)newStack.Max();
        }
    }
}
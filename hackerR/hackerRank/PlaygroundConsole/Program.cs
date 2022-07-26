using PlaygroundConsole.Modules;

namespace PlaygroundConsole;

public static class Program
{
    private static void Main()
    {
        var input = "";
        int choice = Int32.MaxValue;
        Console.WriteLine($"Enter choice {Environment.NewLine} 1-MultiMap {Environment.NewLine} 2-Reverse");
        input =  Console.ReadLine();

        while (!int.TryParse(input, out choice) && choice <= 2)
        {
            Console.WriteLine($"Enter choice {Environment.NewLine} 1-MultiMap {Environment.NewLine} 2-Reverse");
            
        }

        Console.WriteLine(choice);
        switch (choice)
        {
            case 1: 
                // Create first MultiMap.
                var multiMap = new MultiMap<bool>();
                multiMap.Add("key1", true);
                multiMap.Add("key1", false);
                multiMap.Add("key2", false);

                foreach (var key in multiMap.Keys)
                {
                    foreach (var value in multiMap[key])
                    {
                        Console.WriteLine("MULTIMAP: " + key + "=" + value);
                    }
                }

                // Create second MultiMap.
                var multiMap2 = new MultiMap<string>();
                multiMap2.Add("animal", "cat");
                multiMap2.Add("animal", "dog");
                multiMap2.Add("human", "tom");
                multiMap2.Add("human", "tim");
                multiMap2.Add("mineral", "calcium");

                foreach (var key in multiMap2.Keys)
                {
                    foreach (var value in multiMap2[key])
                    {
                        Console.WriteLine("MULTIMAP2: " + key + "=" + value);
                    }
                }

                break;
            
            case 2:
                Console.WriteLine("Enter input:");
                var enteredInput = Console.ReadLine();
                Console.WriteLine($"Input: {enteredInput} {Environment.NewLine}Reversed: {Reverser.Output(enteredInput!)}");
                break;
            
            default: break;
        }

        Console.ReadKey();
    }
}
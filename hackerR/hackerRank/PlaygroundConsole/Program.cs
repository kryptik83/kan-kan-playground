using PlaygroundConsole.Modules;
using PlaygroundConsole.Sorting;

namespace PlaygroundConsole;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("UnsortedArray");
        var unsortedArray = new[] {4, 1, 8, 5, 3, 6};
        foreach (var i in unsortedArray)
            Console.Write($"{i} --> ");
        
        Console.WriteLine($"{Environment.NewLine}BubbleSort");
        var sortedArray = new BubbleSort().Sort(unsortedArray);
        foreach (var i in sortedArray)
            Console.Write($"{i} --> ");
        
        Console.WriteLine($"{Environment.NewLine}MergeSort");
        var mergeUnsortedArray = new[] {4, 1, 8, 5, 3, 6};
        var mergeSortedArray = new MergeSort().Sort(mergeUnsortedArray);
        foreach (var i in mergeSortedArray)
            Console.Write($"{i} --> ");
        
        Console.WriteLine($"{Environment.NewLine}InsertionSort");
        var insertionUnsortedArray = new[] {4, 1, 8, 5, 3, 6};
        var insertionSortedArray = new InsertionSort().Sort(insertionUnsortedArray);
        foreach (var i in insertionSortedArray)
            Console.Write($"{i} --> ");
        
        Console.WriteLine($"{Environment.NewLine}SelectionSort");
        var selectionUnsortedArray = new[] {4, 1, 8, 5, 3, 6};
        var selectionSortedArray = new SelectionSort().Sort(selectionUnsortedArray);
        foreach (var i in selectionSortedArray)
            Console.Write($"{i} --> ");
        
        Console.WriteLine($"{Environment.NewLine}QuickSort");
        var quickUnsortedArray = new[] {4, 1, 8, 5, 3, 6};
        var quickSortedArray = new QuickSort().Sort(quickUnsortedArray);
        foreach (var i in quickSortedArray)
            Console.Write($"{i} --> ");

        Console.ReadKey();
        
        
        Console.WriteLine("ArrayList");
        var arr = new ArrayListImplementation().GenerateArrayList();
        foreach (var item in arr)
            Console.WriteLine(item);
        
        var input = "";
        int choice = Int32.MaxValue;
        Console.WriteLine($"Enter choice {Environment.NewLine} 1-MultiMap {Environment.NewLine} 2-Reverse {Environment.NewLine} 3-FizzBuzz");
        input =  Console.ReadLine();

        while (!int.TryParse(input, out choice) && choice <= 2)
        {
            Console.WriteLine($"Enter choice {Environment.NewLine} 1-MultiMap {Environment.NewLine} 2-Reverse {Environment.NewLine} 3-FizzBuzz");
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
                //regular reverse
                Console.WriteLine($"Input: {enteredInput} {Environment.NewLine}Reversed: {Reverser.Output(enteredInput!)} {Environment.NewLine} {Reverser.OnlyAlphabetical(enteredInput!)}");
                break;
            
            case 3: 
                Console.WriteLine("Enter input:");
                var num = Console.ReadLine() ?? string.Empty;
                Console.WriteLine(AlgoDaily.FizzBuzz(int.TryParse(num, out int number) ? number : 0));
                break;
            
            default: break;
        }

        Console.ReadKey();
    }
}
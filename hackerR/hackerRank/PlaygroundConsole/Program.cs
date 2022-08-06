using PlaygroundConsole.DataStructures;
using PlaygroundConsole.Modules;
using PlaygroundConsole.Practice.AlgoDaily;
using PlaygroundConsole.Practice.Codility;
using PlaygroundConsole.Search;
using PlaygroundConsole.Sorting;
using Math = System.Math;

namespace PlaygroundConsole;

public static class Program
{
    private static void Main()
    {
        var intArray = new int[500];
        for (var x = 0; x < intArray.Length; x++) intArray[x] = x + 1;
        intArray.RightRotate(214);
        Console.WriteLine(intArray[76]);
        Console.WriteLine(intArray[39]);
        Console.ReadLine();
        
        var randNumberCollections = new[] {1, 4, 6, 7, 6, 4, 1};
        Console.WriteLine($"Lone Ranger for {string.Join(",", randNumberCollections)}: {LoneRanger.Get(randNumberCollections)}");
        randNumberCollections = new[] {3, 3, 9};
        Console.WriteLine($"Lone Ranger for {string.Join(",", randNumberCollections)}: {LoneRanger.Get(randNumberCollections)}");
        randNumberCollections = new[] {3, 3, 3};
        Console.WriteLine($"Lone Ranger for {string.Join(",", randNumberCollections)}: {LoneRanger.Get(randNumberCollections)}");

        Console.ReadLine();
        while(true)
        {
            Console.WriteLine("Enter a number: ");
            var inp = Console.ReadLine();
            var numberMila = Int32.TryParse(inp, out var numero);
            if (!numberMila && inp == "q") break;
            var result = BinaryGap.FindBiggest(numero);
            Console.WriteLine($"Number ==> {numero}{Environment.NewLine}Binary ==> {result.BinaryRepresentation}{Environment.NewLine}" + $"Biggest gap ==> {result.BiggestGap}");
            Console.WriteLine();
        }

        /*
                A
               / \
              B   D
             /   / \
            C   E   F
         */
        var myTree = new Tree<string>("A");
        myTree.Root.AddLeft("B").AddLeft("C");
        var right = myTree.Root.AddRight("D");
        right.AddLeft("E");
        right.AddRight("F");
        
        TreeSearch<string>.BFS(myTree);

        Console.WriteLine($"{Environment.NewLine}DFS");
        TreeSearch<string>.DFS(myTree.Root);

        Console.ReadLine();

        // Dictionary<int, int> dict = new();
        // dict[1] = 1;
        // Console.Write(dict[1]);
        // Console.ReadLine();
        
        int[] arrWithDupes = new[] {1, 2, 3, 3, 3, 3, 3, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7};
        var uniqueItemCount = 0;
        for (var ix = 0; ix < arrWithDupes.Length; ix++)
        {
            if (ix == 0 || arrWithDupes[ix] != arrWithDupes[ix - 1])
            {
                arrWithDupes[uniqueItemCount] = arrWithDupes[ix];
                uniqueItemCount++;
            }
            else if (arrWithDupes[ix] == arrWithDupes[ix - 1]) continue;
        }
        Console.WriteLine(uniqueItemCount);
        Console.ReadLine();
        
        Console.WriteLine(MyMath.ExtraLongFactorial(100));
        Console.ReadLine();
        
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

        Console.WriteLine($"{Environment.NewLine}HeapSort");
        var heapUnsortedArray = new[] {4, 1, 8, 5, 3, 6};
        var heapSortedArray = new QuickSort().Sort(heapUnsortedArray);
        foreach (var i in heapSortedArray)
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
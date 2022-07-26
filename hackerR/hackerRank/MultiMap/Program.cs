namespace MultiMap;

//MultiMap. A MultiMap has multiple values at a key. With it we add multiple values to a single key in a Dictionary. MultiMaps can be useful.
public class MultiMap<T>
{
    private readonly Dictionary<string, List<T>> _dictionary = new();

    public void Add(string key, T value)
    {
        // Add a key.
        if (_dictionary.TryGetValue(key, out var list))
            list.Add(value);
        else
            _dictionary[key] = new List<T> {value};
    }

    // Get all keys.
    public IEnumerable<string> Keys => _dictionary.Keys;
    
    //Indexer => https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
    public List<T> this[string key]
    {
        get
        {
            // Get list at a key.
            if (!_dictionary.TryGetValue(key, out var list))
            {
                list = new List<T>();
                _dictionary[key] = list;
            }

            return list;
        }
    }
}

class Program
{
    static void Main()
    {
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

        Console.ReadKey();
    }
}
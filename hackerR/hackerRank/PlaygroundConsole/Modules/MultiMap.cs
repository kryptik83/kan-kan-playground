namespace PlaygroundConsole.Modules;

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
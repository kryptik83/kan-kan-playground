namespace PlaygroundConsole.Cache;

/// <summary>
/// LRU Cache implementation [LRU = Least Recently Used]
/// </summary>
// ReSharper disable once InconsistentNaming
public class LRU
{
    private readonly int _size;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _dictionary;
    private readonly LinkedList<KeyValuePair<int, int>> _list;

    public LRU(int capacity = 50)
    {
        _size = capacity;
        _dictionary = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        _list = new LinkedList<KeyValuePair<int, int>>();
    }

    public int Get(int key)
    {
        if (!_dictionary.ContainsKey(key)) return -1;
        var value = _dictionary[key]
            .Value.Value;
        Put(key, value);
        return value;
    }

    public void Put(int key, int value)
    {
        if (_dictionary.ContainsKey(key))
        {
            var nodeToRemove = _dictionary[key];
            _dictionary.Remove(key);
            _list.Remove(nodeToRemove);
        }
        else
        {
            if (_list.Count >= this._size)
            {
                var nodeToRemove = _list.First;
                if (nodeToRemove != null)
                {
                    _dictionary.Remove(nodeToRemove.Value.Key);
                    _list.RemoveFirst();
                }
            }
        }

        _dictionary[key] = _list.AddLast(new KeyValuePair<int, int>(key, value));
    }
}
using System.Collections;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace PlaygroundConsole.Interview.ServiceTitan;

public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V> where K : notnull
{
    private readonly Dictionary<K, HashSet<V>> _dictionary = new();

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator() => Flatten()
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<V> Get(K key)
    {
        if (!_dictionary.ContainsKey(key))
            throw new KeyNotFoundException(nameof(key));
        return _dictionary[key];
    }

    public IEnumerable<V> GetOrDefault(K key) => !_dictionary.ContainsKey(key) ? new HashSet<V>() : _dictionary[key];

    public void Remove(K key, V value)
    {
        var curValueCollection = Get(key)?.ToHashSet() ?? new HashSet<V>();
        var _ = curValueCollection.Remove(value);

        if (!curValueCollection.Any())
            _dictionary.Remove(key);
        else
            _dictionary[key] = curValueCollection;
    }

    public void Clear(K key)
    {
        if (_dictionary.ContainsKey(key))
            _dictionary.Remove(key);
    }

    public bool Add(K key, V value)
    {
        if (_dictionary.ContainsKey(key))
        {
            var curValues = _dictionary[key];
            var addResult = curValues.Add(value);

            _dictionary[key] = curValues;
            return addResult;
        }
        else
        {
            _dictionary[key] = new HashSet<V> {value};
            return true;
        }
    }

    public IEnumerable<KeyValuePair<K, V>> Flatten()
    {
        var retCollection = new List<KeyValuePair<K, V>>();
        foreach(var key in _dictionary.Keys)
            foreach(var val in _dictionary[key])
                retCollection.Add(new KeyValuePair<K, V>(key, val));

        return retCollection;
    }
}

public interface IMultiValueDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
{
    IEnumerable<V> Get(K key);
    IEnumerable<V> GetOrDefault(K key);
    void Remove(K key, V value);
    void Clear(K key);
    bool Add(K key, V value);
    IEnumerable<KeyValuePair<K, V>> Flatten();
}
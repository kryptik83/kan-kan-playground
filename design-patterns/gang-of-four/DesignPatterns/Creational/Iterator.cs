using System.Collections;

namespace DesignPatterns.Creational;

public class Item
{
    public string ItemValue { get; set; }
}

public class ItemEnumerator : IEnumerator<Item>
{
    private int string = def
    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public Item Current { get; } => 
    object IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public class ItemCollection : IEnumerable<Item>
{
    public IEnumerator<Item> GetEnumerator() => new ItemEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
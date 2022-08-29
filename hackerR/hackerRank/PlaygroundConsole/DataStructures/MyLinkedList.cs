namespace PlaygroundConsole.DataStructures;

public class MyLinkedList<T> where T : notnull
{
    public MyLinkedListNode<T>? Head { get; private set; }
    public MyLinkedListNode<T>? Tail { get; private set; }
    
    public MyLinkedList()
    {
        Head = null;
        Tail = null;
    }

    public MyLinkedList(T value) => AddFirst(value);

    public MyLinkedList(IEnumerable<T> values)
    {
        foreach (var value in values) 
            AddLast(value);
    }

    public void AddFirst(T newHead)
    {
        var newNode = new MyLinkedListNode<T>(newHead);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
    }

    public void AddLast(T tail)
    {
        var node = new MyLinkedListNode<T>(tail);
        if (Tail == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = Tail.Next;
        }
    }
}

public class MyLinkedListNode<T> where T : notnull
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public T Value { get; set; }
    public MyLinkedListNode<T>? Next { get; set; }

    public MyLinkedListNode(T value, MyLinkedListNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}
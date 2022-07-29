namespace PlaygroundConsole.DataStructures;

public class Tree<T>
{
    public Tree(T value) => Root = new Node<T>(value);
    public Node<T> Root { get; set; }
}

public class Node<T>
{
    public T Val { get; set; }
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }
    public Node(T value) => Val = value;

    public Node<T> AddLeft(T value)
    {
        Left = new Node<T>(value);
        return Left;
    }

    public Node<T> AddRight(T value)
    {
        Right = new Node<T>(value);
        return Right;
    }
}
using System.Diagnostics.CodeAnalysis;
using PlaygroundConsole.DataStructures;

namespace PlaygroundConsole.Search;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class TreeSearch<T>
{
    public static void BFS(Tree<T> tree)
    {
        Queue<Node<T>> _queue = new();
        _queue.Enqueue(tree.Root);
        Console.WriteLine("BFS");
        while (_queue.Count > 0)
        {
            var item = _queue.Dequeue();
            Console.Write(item.Val + " --> ");
            if (item.Left != null) _queue.Enqueue(item.Left);
            if (item.Right != null) _queue.Enqueue(item.Right);
        }
        Console.WriteLine();
    }

    public static void DFS(Node<T> node)
    {
        Console.Write(node.Val + " --> ");
        if (node.Left != null) DFS(node.Left);
        if (node.Right != null) DFS(node.Right);
    }
}
using NUnit.Framework;

namespace PlaygroundConsole.Search;

public static class Traversal
{
    public static List<int> InorderTraversal(Node? root)
    {
        var abc = new List<int>();
        if (root == null) return abc;

        var leftRange = InorderTraversal(root.Left);
        if (leftRange.Any())
            abc.AddRange(leftRange);

        abc.Add(root.Val);

        var rightRange = InorderTraversal(root.Right);
        if (rightRange.Any())
            abc.AddRange(rightRange);

        return abc;
    }
}

// available data structures

public class Node
{
    public readonly int Val;
    public Node? Left;
    public Node? Right;

    public Node(int val)
    {
        this.Val = val;
    }
}

[TestFixture]
public class Tests
{
    private Node? _tree0;
    private Node? _tree2;
    private Node? _tree3;
    private Node? _tree5;

    [SetUp]
    public void SetUp()
    {
        _tree0 = new Node(4)
        {
            Left = null,
            Right = new Node(5)
            {
                Left = new Node(6)
            }
        };

        _tree2 = new Node(5)
        {
            Left = new Node(10)
            {
                Left = new Node(17),
                Right = new Node(3)
            },
            Right = new Node(8)
        };

        // Binary search trees
        _tree3 = new Node(6)
        {
            Left = new Node(3)
        };

        _tree5 = new Node(8)
        {
            Left = new Node(6),
            Right = new Node(9)
        };
        _tree5.Left.Left = new Node(5);
        _tree5.Left.Right = new Node(7);
        _tree5.Right.Right = new Node(10);
    }

    // tests
    [Test]
    public void PracticeAlgoDailyInOrderTraversal() => CollectionAssert.AreEqual(Traversal.InorderTraversal(_tree0), new[] {4, 6, 5});

    [Test]
    public void MediumSizedTreeInorderTraversalTest() => CollectionAssert.AreEqual(Traversal.InorderTraversal(_tree2), new[] {17, 10, 3, 5, 8});

    [Test]
    public void TinyTreeInorderTraversalTest() => CollectionAssert.AreEqual(Traversal.InorderTraversal(_tree3), new[] {3, 6});
}
using System.Diagnostics.CodeAnalysis;
using static PlaygroundConsole.Practice.AlgoDaily.GrabRandomNode;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
[SuppressMessage("Assertion",
    "NUnit2009:The same value has been provided as both the actual and the expected argument")]
public class GrabRandomNodeTests
{
    private LinkedList<int> _list1 = new();
    private LinkedList<int> _list2 = new();

    [SetUp]
    public void SetUp()
    {
        _list1 = new LinkedList<int>(new[] {3, 4, 5, 6, 7, 8, 9, 10});
        _list2 = new LinkedList<int>(new[] {1, 2, 3, 4, 5, 6, 7, 8});
    }

    private static List<int> ToList(LinkedListNode<int>? head)
    {
        var res = new List<int>();
        while (head != null)
        {
            res.Add(head.Value);
            head = head.Next;
        }

        return res;
    }

    [Test]
    public void RandomFromFirstListTest() => Assert.That(Get(_list1), Is.Not.EqualTo(Get(_list1)));

    [Test]
    public void RandomFromSecondListTest() => Assert.That(Get(_list2), Is.Not.EqualTo(Get(_list2)));
}
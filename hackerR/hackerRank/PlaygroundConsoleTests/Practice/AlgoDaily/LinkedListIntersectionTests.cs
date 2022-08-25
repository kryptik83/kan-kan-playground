using FluentAssertions.Execution;
using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class LinkedListIntersectionTests
{
    private LinkedList<int> _list1 = new();
    private LinkedList<int> _list2 = new();

    [SetUp]
    public void SetUp()
    {
        _list1 = new LinkedList<int>(new[] {3, 4, 5, 6, 7, 8, 9, 10});
        _list2 = new LinkedList<int>(new[] {1, 2, 3, 4, 5, 6, 7, 8});
    }

    [Test]
    public void IntersectionWithMoreThanOneCommonElementsTest()
    {
        var intersectingList = LinkedListIntersection<int>.Get(_list1, _list2);
        using (new AssertionScope())
        {
            Assert.That(intersectingList.Count, Is.EqualTo(6));
            Assert.That(intersectingList.First!.Value, Is.EqualTo(3));
        }
    }
    
    [Test]
    public void IntersectionWithOneCommonElementTest()
    {
        var list1 = new LinkedList<int>();
        list1.AddFirst(25);
        list1.AddFirst(15);
        list1.AddFirst(5);
        list1.AddFirst(9);
        var list2 = new LinkedList<int>();
        list2.AddFirst(14);
        list2.AddFirst(15);
        list2.AddFirst(7);
        list2.AddFirst(13);

        var intersectingList = LinkedListIntersection<int>.Get(list1, list2);
        using (new AssertionScope())
        {
            Assert.That(intersectingList.Count, Is.EqualTo(1));
            Assert.That(intersectingList.First!.Value, Is.EqualTo(15));
        }
    }
}
using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class UnionOfTwoLinkedListsTests
{
    private LinkedList<int> _list1 = new();
    private LinkedList<int> _list2 = new();

    [SetUp]
    public void SetUp()
    {
        _list1 = new LinkedList<int>(new[] {4, 5, 6, 7, 8, 9, 10});
        _list2 = new LinkedList<int>(new [] {2, 3, 4, 5, 6, 7, 8});
    }

    [Test]
    public void UnionOfListsHavingManyMatchingElementsTest()
    {
        var union = UnionOfTwoLinkedLists<int>.GetUnion(_list1, _list2);
        Assert.True(new[] {2, 3, 4, 5, 6, 7, 8, 9, 10}.All(item => union.Contains(item)));
    }

    [Test]
    public void UnionOfListsHavingMatchingElementTest()
    {
        _list1 = new LinkedList<int>(new[] {25,15,5,9});
        _list2 = new LinkedList<int>(new [] {14,15,7,13});
        var union = UnionOfTwoLinkedLists<int>.GetUnion(_list1, _list2);
        Assert.True(new[] {13, 7, 14, 25, 15, 5, 9}.All(item => union.Contains(item)));
    }
}
using FluentAssertions.Execution;
using PlaygroundConsole.DataStructures;

namespace PlaygroundConsoleTests.DataStructures;

[TestFixture]
public class MyLinkedListTests
{
    [Test]
    public void EmptyListTest()
    {
        var mll = new MyLinkedList<bool>();
        Assert.Multiple(() =>
        {
            Assert.That(mll.Head, Is.Null);
            Assert.That(mll.Tail, Is.Null);
        });

    }
    [Test]
    public void NewLinkedListWithOneValue()
    {
        var tokenValue = "a";
        var mll = new MyLinkedList<string>(tokenValue);
        using (new AssertionScope())
        {
            Assert.That(mll.Head?.Value, Is.EqualTo(tokenValue));
            Assert.That(mll.Tail?.Value, Is.EqualTo(tokenValue));
        }
    }

    [Test]
    public void NewLinkedListWithManyValues()
    {
        var tokenValue = new[] {"a", "b", "c"};

        var mll = new MyLinkedList<string>(tokenValue);
        using (new AssertionScope())
        {
            Assert.That(mll.Head?.Value, Is.EqualTo(tokenValue[0]));
            Assert.That(mll.Tail?.Value, Is.EqualTo(tokenValue[^1])); //last element ^ means end
        }
    }

    [Test]
    public void AddFirstTest()
    {
        var list = new MyLinkedList<int>();
        list.AddFirst(12);
        list.AddFirst(11);
        list.AddFirst(10);

        using (new AssertionScope())
        {
            Assert.That(list.Head?.Value, Is.EqualTo(10));
            Assert.That(list.Tail?.Value, Is.EqualTo(12));
        }
    }

    [Test]
    public void AddLastTest()
    {
        var list = new MyLinkedList<int>();
        list.AddLast(12);
        list.AddLast(11);
        list.AddLast(10);

        using (new AssertionScope())
        {
            Assert.That(list.Head?.Value, Is.EqualTo(12));
            Assert.That(list.Tail?.Value, Is.EqualTo(10));
        }
    }
}
using NUnit.Framework;
using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class SwapNodePairsInLinkedListTests
{
    [Test]
    public void EvenLengthListTest() =>
        CollectionAssert.AreEqual(SwapNodePairsInLinkedList<int>.Get(new LinkedList<int>(new[] {3, 4, 5, 6})),
            new int[] {4, 3, 6, 5});

    [Test]
    public void OddLengthListTest() =>
        CollectionAssert.AreEqual(SwapNodePairsInLinkedList<int>.Get(new LinkedList<int>(new[] {3, 4, 5, 6, 7})),
            new int[] {4, 3, 6, 5, 7});

    [Test]
    public void EmptyListTest() =>
        CollectionAssert.AreEqual(SwapNodePairsInLinkedList<int>.Get(new LinkedList<int>()), Array.Empty<int>());
}
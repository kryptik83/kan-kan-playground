using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class MissingNumberInArrayTests
{
    [Test]
    public void OnlyOneMissingTest() => CollectionAssert.AreEqual(MissingNumberInArray.MissingNumbers(new int[] {0, 1, 3}), new int[] {2});

    [Test]
    public void MultipleMissingTest() => CollectionAssert.AreEqual(MissingNumberInArray.MissingNumbers(new int[] {10, 11, 14, 17}), new int[] {12, 13, 15, 16});

    [Test]
    public void MoreNumbersMissingThanNotTest() => CollectionAssert.AreEqual(MissingNumberInArray.MissingNumbers(new int[] {3, 7, 9, 19}), new int[] {4, 5, 6, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18});
}
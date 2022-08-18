using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class UniquenessArraysTests
{
    [Test]
    public void HugeArrayWithFewDuplicationsTest()
    {
        CollectionAssert.AreEqual(UniquenessArrays.Uniques(new int[] {8, 8, 15, 6, 19, 7, 12, 6, 6, 3, 13, 9, 15, 14, 1, 13, 4, 11, 16}), new int[] {8, 15, 6, 19, 7, 12, 3, 13, 9, 14, 1, 4, 11, 16});
    }

    [Test]
    public void LostOfDuplicationsTest()
    {
        CollectionAssert.AreEqual(UniquenessArrays.Uniques(new int[] {12, 7, 2, 20, 20, 2, 15, 20, 2, 10, 12, 1}), new int[] {12, 7, 2, 20, 15, 10, 1});
    }

    [Test]
    public void MediumArrayWithFewDuplicationsTest()
    {
        CollectionAssert.AreEqual(UniquenessArrays.Uniques(new int[] {6, 12, 5, 1, 4, 18, 10, 17, 10, 0, 1, 7, 6, 18, 11, 2, 15, 19}), new int[] {6, 12, 5, 1, 4, 18, 10, 17, 0, 7, 11, 2, 15, 19});
    }

    [Test]
    public void HugeArrayWithSeveralDuplicationsTest()
    {
        CollectionAssert.AreEqual(UniquenessArrays.Uniques(new int[] {9, 0, 11, 16, 19, 14, 7, 18, 10, 6, 0, 17, 12, 9, 12, 18, 0, 14, 17}), new int[] {9, 0, 11, 16, 19, 14, 7, 18, 10, 6, 17, 12});
    }

    [Test]
    public void MediumArrayWithMultipleDuplicationsTest()
    {
        CollectionAssert.AreEqual(UniquenessArrays.Uniques(new int[] {5, 10, 3, 17, 9, 12, 19, 4, 16, 19, 7, 9, 7, 8, 10}), new int[] {5, 10, 3, 17, 9, 12, 19, 4, 16, 7, 8});
    }
}
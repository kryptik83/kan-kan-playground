using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

public class FastMinimumInRotatedArrayTests
{
    [Test]
    public void MinimumInFirstHalfTest() => Assert.That(FastMinimumInRotatedArray.GetMinimum(new int[] {6, 7, 8, 0, 1, 2, 3, 4, 5}), Is.EqualTo(0));

    [Test]
    public void MinimumInSecondHalfTest() => Assert.That(FastMinimumInRotatedArray.GetMinimum(new int[] {6, 7, 8, 9, 10, 3, 4, 5}), Is.EqualTo(3));
}
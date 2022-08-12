using PlaygroundConsole;

namespace PlaygroundConsoleTests.Practice;

[TestFixture]
public class MaxOfMinPairTests
{
    [Test]
    public void SmallArrayTest() => Assert.That(MaxOfMinPairs.Compute(new[] {3, 4, 2, 5}), Is.EqualTo(6));

    [Test]
    public void LargeArrayTest() => Assert.That(MaxOfMinPairs.Compute(new[] {1, 3, 2, 6, 5, 4}), Is.EqualTo(9));

    [Test]
    public void EmptyArrayTest() => Assert.That(MaxOfMinPairs.Compute(Array.Empty<int>()), Is.EqualTo(0));
}
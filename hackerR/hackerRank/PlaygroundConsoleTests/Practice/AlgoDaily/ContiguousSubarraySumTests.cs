using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class ContiguousSubarraySumTests
{
    [Test]
    public void SimpleSumTest() => Assert.That(ContiguousSubarraySum.SubarraySum(new[] {1, 2, 3}, 3), Is.EqualTo(true));

    [Test]
    public void SimpleSumTest2() => Assert.That(ContiguousSubarraySum.SubarraySum(new[] {1, 2, 3}, 6), Is.EqualTo(true));
    
    [Test]
    public void SimpleSumTest3() => Assert.That(ContiguousSubarraySum.SubarraySum(new[] {1, 2, 5, 3}, 6), Is.EqualTo(false));
    
    [Test]
    public void EmptyArrayTest() => Assert.That(ContiguousSubarraySum.SubarraySum(Array.Empty<int>(), 3), Is.EqualTo(false));

    [Test]
    public void ComplexSumTest() => Assert.That(ContiguousSubarraySum.SubarraySum(new[] {3, 6, 12, 35}, 47), Is.EqualTo(true));
}
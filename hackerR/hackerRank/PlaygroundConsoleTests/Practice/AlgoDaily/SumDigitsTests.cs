using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public partial class SumDigitsTests
{
    [Test]
    public void testOne() => Assert.That(SumDigits.Compute(49), Is.EqualTo(4));

    [Test]
    public void TestTwo() => Assert.That(SumDigits.Compute(1), Is.EqualTo(1));

    [Test]
    public void TestThree() => Assert.That(SumDigits.Compute(439230), Is.EqualTo(3));
}
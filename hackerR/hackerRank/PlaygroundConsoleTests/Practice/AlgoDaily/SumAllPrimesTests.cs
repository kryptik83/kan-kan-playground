using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

public class SumAllPrimesTests
{
    [Test]
    public void SumOfPrimesForTwoTest() => Assert.That(SumAllPrimes.Calculate(2), Is.EqualTo(2), "SumOfPrimes(2) should equal 2");

    [Test]
    public void SumOfPrimesForThirtyTest() => Assert.That(SumAllPrimes.Calculate(30), Is.EqualTo(129), "SumOfPrimes(30) should equal 129");

    [Test]
    public void SumOfPrimesForFiftyFiveTest() => Assert.That(SumAllPrimes.Calculate(55), Is.EqualTo(381), "SumOfPrimes(55) should equal 381");
}
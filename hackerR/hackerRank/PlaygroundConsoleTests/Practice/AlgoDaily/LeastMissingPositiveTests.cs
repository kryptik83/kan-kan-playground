using Microsoft.VisualStudio.TestPlatform.TestHost;
using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class LeastMissingPositiveTests
{
    [Test]
    public void LeastMissingFoundTest() => Assert.That(LeastMissingPositive.Find(new int[] {3, 5, -1, 1}), Is.EqualTo(2));

    [Test]
    public void NoMissingTest() => Assert.That(LeastMissingPositive.Find(new int[] {5, 6, 7, 8, 9}), Is.EqualTo(1));

    [Test]
    public void EmptyArrayTest() => Assert.That(LeastMissingPositive.Find(new int[] { }), Is.EqualTo(1));
}
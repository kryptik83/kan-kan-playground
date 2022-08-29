using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class FibonacciSequenceTests
{
    [Test]
    public void TestStack()
    {
        int[][] cases =
        {
            new[] {2, 2},
            new[] {3, 3},
            new[] {4, 5},
            new[] {5, 8},
            new[] {6, 13},
            new[] {7, 21}
        };

        foreach (var testCase in cases) 
            Assert.That(FibonacciSequence.GetStack(testCase[0]), Is.EqualTo(testCase[1]));
    }
    
    [Test]
    public void TestArray()
    {
        int[][] cases =
        {
            new[] {2, 2},
            new[] {3, 3},
            new[] {4, 5},
            new[] {5, 8},
            new[] {6, 13},
            new[] {7, 21}
        };

        foreach (var testCase in cases) 
            Assert.That(FibonacciSequence.GetArray(testCase[0]), Is.EqualTo(testCase[1]));
    }
    
    [Test]
    public void TestRecursion()
    {
        int[][] cases =
        {
            new[] {2, 2},
            new[] {3, 3},
            new[] {4, 5},
            new[] {5, 8},
            new[] {6, 13},
            new[] {7, 21}
        };

        foreach (var testCase in cases) 
            Assert.That(FibonacciSequence.GetRecursion(testCase[0]), Is.EqualTo(testCase[1]));
    }
}
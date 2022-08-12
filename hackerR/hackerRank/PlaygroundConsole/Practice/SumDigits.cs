using NUnit.Framework;

namespace PlaygroundConsole;

public static class Test
{
    public static int SumDigits(int num)
    {
        if (num < 10) return num;

        var sum = 0;
        while (num > 0)
        {
            var rem = num % 10;
            sum += rem;
            num = (num - rem) / 10;
        }

        return SumDigits(sum);
    }
}

[TestFixture]
public partial class Tests
{
    [Test]
    public void testOne()
    {
        Assert.AreEqual(Test.SumDigits(49), 4);
    }

    [Test]
    public void TestTwo()
    {
        Assert.AreEqual(Test.SumDigits(1), 1);
    }

    [Test]
    public void TestThree()
    {
        Assert.AreEqual(Test.SumDigits(439230), 3);
    }
}
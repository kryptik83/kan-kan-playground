using NUnit.Framework;

namespace PlaygroundConsole;

public static class FirstNonRepeatingCharacter
{
    public static char Solve(string input)
    {
        var map = new Dictionary<char, int>();
        foreach (var c in input)
            map[c] = map.ContainsKey(c) ? ++map[c] : 1;

        foreach (var key in map.Keys)
            if (map[key] == 1)
                return key;

        return default;
    }
}

[TestFixture]
public partial class Tests
{
    [Test]
    public void WhereIsMyCarTest()
    {
        Assert.AreEqual(FirstNonRepeatingCharacter.Solve("oh my god dude where is my car"), 'g');
    }

    [Test]
    public void EmptyStringTest()
    {
        Assert.AreEqual(FirstNonRepeatingCharacter.Solve(""), '\0');
    }


    [Test]
    public void RandomStrTest()
    {
        // ReSharper disable once StringLiteralTypo
        Assert.AreEqual(FirstNonRepeatingCharacter.Solve("asdfsdafdasfjdfsafnnunlfdffvxcvsfansd"), 'j');
    }


    [Test]
    public void SingleCharStringTest()
    {
        Assert.AreEqual(FirstNonRepeatingCharacter.Solve("a"), 'a');
    }
}
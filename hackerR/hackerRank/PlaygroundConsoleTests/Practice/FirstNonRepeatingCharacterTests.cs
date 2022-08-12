using PlaygroundConsole;

namespace PlaygroundConsoleTests.Practice;

[TestFixture]
public class FirstNonRepeatingCharacterTests
{
    [Test]
    public void WhereIsMyCarTest() => Assert.That(FirstNonRepeatingCharacter.Solve("oh my god dude where is my car"), Is.EqualTo('g'));

    [Test]
    public void EmptyStringTest() => Assert.That(FirstNonRepeatingCharacter.Solve(""), Is.EqualTo('\0'));


    [Test]
    public void RandomStrTest() =>
        // ReSharper disable once StringLiteralTypo
        Assert.That(FirstNonRepeatingCharacter.Solve("asdfsdafdasfjdfsafnnunlfdffvxcvsfansd"), Is.EqualTo('j'));


    [Test]
    public void SingleCharStringTest() => Assert.That(FirstNonRepeatingCharacter.Solve("a"), Is.EqualTo('a'));
}
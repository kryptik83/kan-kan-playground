using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class DollarSignDeletionTests
{
    [Test]
    public void MultipleDeletesEqualTest() => Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"ab$$", "c$d$"}));


    [Test]
    public void SimpleDollarDeleteTest() => Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"f$ec", "ec"}));


    [Test]
    public void ComplexEqualTest() => Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"b$$p", "$b$p"}));


    [Test]
    public void ComplexDeletesNotEqualTest() => Assert.False(DollarSignDeletion.IsDollarDeleteEqual(new[] {"a90$n$c$se", "a90n$cse"}));
}
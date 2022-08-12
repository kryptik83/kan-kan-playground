using NUnit.Framework;

namespace PlaygroundConsole;

public static class DollarSignDeletion
{
    public static bool IsDollarDeleteEqual(string[] arr)
    {
        if (arr.Length != 2) return false;
        return GetSanitizedString(arr[0]).SequenceEqual(GetSanitizedString(arr[1]));
    }

    private static string GetSanitizedString(string inputString)
    {
        var stack = new Stack<char>();
        foreach (var ch in inputString)
        {
            if (ch != '$')
                stack.Push(ch);
            else
            {
                if (stack.Count > 0)
                    stack.Pop();
            }
        }

        var computedFinalString = string.Empty;
        while (stack.Count > 0)
            computedFinalString = stack.Pop() + computedFinalString;

        return computedFinalString;
    }
}

// tests
[TestFixture]
public partial class Tests
{
    [Test]
    public void MultipleDeletesEqualTest()
    {
        Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"ab$$", "c$d$"}));
    }


    [Test]
    public void SimpleDollarDeleteTest()
    {
        Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"f$ec", "ec"}));
    }


    [Test]
    public void ComplexEqualTest()
    {
        Assert.True(DollarSignDeletion.IsDollarDeleteEqual(new[] {"b$$p", "$b$p"}));
    }


    [Test]
    public void ComplexDeletesNotEqualTest()
    {
        Assert.False(DollarSignDeletion.IsDollarDeleteEqual(new[] {"a90$n$c$se", "a90n$cse"}));
    }
}
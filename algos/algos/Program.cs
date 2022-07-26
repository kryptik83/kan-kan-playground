
using System.Text;

var a = new ArrayList<int>();

Console.WriteLine(ReversedWordsInString("Madam Im Adam"));




string ReversedWordsInString(string input)
{
    if (string.IsNullOrEmpty(input)) return input;
    var words = input.Split(' ');
    var sb = new StringBuilder();
    foreach (string word in words)
    {
        var revWord = new String(word.ToCharArray().Reverse().ToArray());
        sb.Append($"{revWord} ");
    }

    var newstr = sb.ToString();

    return newstr;
}

// Console.WriteLine(new String("abc".Reverse().ToArray()));
// Console.WriteLine(findMaxOfThree(10, 6, 11));
// Console.WriteLine(isUpperCase("hello"));
// Console.WriteLine(isUpperCase("Hello"));
// Console.WriteLine(isUpperCase("HELLO"));
// TraverseEvenLocations("chariot");
// Console.WriteLine("abc".Replace('a', 'd'));


// static int findMaxOfTwo(int a, int b) => a > b ? a : b;
// static int findMaxOfThree(int a, int b, int c)
//     => findMaxOfTwo(findMaxOfTwo(a, b), c);

// static Boolean isUpperCase(string s) =>
//     s.ToCharArray().All(ch => char.IsUpper(ch));

// static void TraverseEvenLocations(string s)
// {
//     if (string.IsNullOrEmpty(s)) return;
//     for (int i = 0; i < s.Length; i = i + 2)
//         Console.WriteLine(s[i]);
// }
using System.Text;

namespace PlaygroundConsole.Modules;

//3https://algodaily.com/challenge_slides/fizz-buzz
public static class AlgoDaily
{
    public static string FizzBuzz(int num)
    {
        var sb = new StringBuilder();
        for (var i = 1; i <= num; i++)
        {
            var stringToAppend = (i % 15) == 0 ? "fizzbuzz" : (i % 5) == 0 ? "buzz" : (i % 3) == 0 ? "fizz" : i.ToString();
            sb.Append(stringToAppend);
        }

        return sb.ToString();
    }
}
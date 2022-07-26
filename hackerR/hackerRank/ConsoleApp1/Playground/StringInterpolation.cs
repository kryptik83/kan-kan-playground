namespace ConsoleApp1.Playground;

public class StringInterpolation
{
    public void Write()
    {
        var sentence = $"I am in {GetType().FullName}. Method name is {nameof(Write)}";
        Console.WriteLine(sentence);
    }
}
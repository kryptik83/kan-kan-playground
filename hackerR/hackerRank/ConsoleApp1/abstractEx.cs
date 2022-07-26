namespace ConsoleApp1;

public abstract class AbstractEx
{
    public abstract int GetRandomInt();
    public virtual Guid GetIdentifier() => Guid.Empty;

}

public class InheritedFromAbstract : AbstractEx
{
    public override int GetRandomInt() => new Random().Next();
}

public class InheritedFromAbstract2 : AbstractEx
{
    public override int GetRandomInt() => new Random(100).Next();
}
using PlaygroundConsole.Practice.AlgoDaily;

namespace PlaygroundConsoleTests.Practice.AlgoDaily;

[TestFixture]
public class ProductExceptSelfTests
{
    [Test]
    public void EmptyArrayTest() =>
        CollectionAssert.AreEqual(ProductExceptSelf.Solve(Array.Empty<int>()), Array.Empty<int>());

    [Test]
    public void MediumArrayTest() => CollectionAssert.AreEqual(
        ProductExceptSelf.Solve(new[] {7, 8, 5, 18, 16, 11, 20}),
        new[] {2534400, 2217600, 3548160, 985600, 1108800, 1612800, 887040});

    [Test]
    public void HugeArrayTest() => CollectionAssert.AreEqual(
        ProductExceptSelf.Solve(new[] {9, 9, 3, 4, 18, 8, 6, 18, 1, 6, 19}),
        new[]
        {
            191476224, 191476224, 574428672, 430821504, 95738112, 215410752, 287214336, 95738112, 1723286016, 287214336,
            90699264
        });

    [Test]
    public void PowerOfTwosTest() =>
        CollectionAssert.AreEqual(ProductExceptSelf.Solve(new[] {1, 2, 4, 16}), new[] {128, 64, 32, 8});
}
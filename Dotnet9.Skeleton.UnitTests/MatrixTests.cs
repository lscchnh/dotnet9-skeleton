namespace Dotnet9.Skeleton.UnitTests;

public class MatrixTests
{
    [Test]
    [MatrixDataSource]
    public async Task MyTest(
    [Matrix<int>(1, 2, 3)] int value1,
    [Matrix<int>(1, 2, 3)] int value2
    )
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsPositive();
    }

    [Test]
    [MatrixDataSource]
    public async Task MyTest2(
        [MatrixRange<int>(1, 10)] int value1,
        [MatrixRange<int>(1, 10)] int value2
        )
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsPositive();
    }

    [Test]
    [MatrixDataSource]
    public async Task MyTest3(
    [MatrixMethod<MatrixTests>(nameof(Numbers))] int value1,
    [MatrixMethod<MatrixTests>(nameof(Numbers))] int value2
    )
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsPositive();
    }

    private static int Add(int x, int y)
    {
        return x + y;
    }

    // MatrixMethod impl needs to keep this public static
    public static IEnumerable<int> Numbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
        yield return 6;
        yield return 7;
        yield return 8;
        yield return 9;
        yield return 10;
    }
}

﻿using Dotnet9.Skeleton.UnitTests.Data;

namespace Dotnet9.Skeleton.UnitTests;

public class Tests
{
    #region Basic Test

    [Test]
    public void Basic()
    {
        Console.WriteLine("This is a basic test");
    }

    #endregion

    #region Tests with simple arguments
    [Test]
    [Arguments(1, 2, 3)]
    [Arguments(2, 3, 5)]
    public async Task DataDrivenArguments(int a, int b, int c)
    {
        Console.WriteLine("This one can accept arguments from an attribute");

        var result = a + b;

        await Assert.That(result).IsEqualTo(c);
    }

    #endregion

    #region Tests with MethodDataSource

    public static IEnumerable<(int a, int b, int c)> DataSource()
    {
        yield return (1, 1, 2);
        yield return (2, 1, 3);
        yield return (3, 1, 4);
    }

    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task MethodDataSource(int a, int b, int c)
    {
        Console.WriteLine("This one can accept arguments from a method");

        var result = a + b;

        await Assert.That(result).IsEqualTo(c);
    }

    #endregion

    #region Tests with ClassDataSource (DataClass class)

    [Test]
    [ClassDataSource<DataClass>]
    [ClassDataSource<DataClass>(Shared = SharedType.PerClass)]
    [ClassDataSource<DataClass>(Shared = SharedType.PerAssembly)]
    [ClassDataSource<DataClass>(Shared = SharedType.PerTestSession)]
    public void ClassDataSource(DataClass dataClass)
    {
        Console.WriteLine("This test can accept a class, which can also be pre-initialised before being injected in");

        Console.WriteLine("These can also be shared among other tests, or new'd up each time, by using the `Shared` property on the attribute");
    }

    #endregion

    #region Tests with Custom DataGenerator (DataGenerator class)

    [Test]
    [DataGenerator]
    public async Task CustomDataGenerator(int a, int b, int c)
    {
        Console.WriteLine("You can even define your own custom data generators");

        var result = a + b;

        await Assert.That(result).IsEqualTo(c);
    }

    #endregion
}
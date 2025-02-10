using Dotnet9.Skeleton.UnitTests.Data;

namespace Dotnet9.Skeleton.UnitTests;

[ClassDataSource<DataClass>]
[ClassConstructor<DependencyInjectionClassConstructor>]
public class AndEvenMoreTests(DataClass dataClass)
{
    #region Tests using Dataclass coming from class level as ClassDataSource (DataClass class) and ClassConstructor (DependencyInjectionClassConstructor class)

    [Test]
    public void HaveFun()
    {
        Console.WriteLine(dataClass);
        Console.WriteLine("For more information, check out the documentation");
        Console.WriteLine("https://thomhurst.github.io/TUnit/");
    }

    #endregion
}
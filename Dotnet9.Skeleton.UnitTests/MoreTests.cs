using Dotnet9.Skeleton.UnitTests.Data;

namespace Dotnet9.Skeleton.UnitTests;

[Arguments("Hello")]
[Arguments("World")]
public class MoreTests(string title)
{
    // You can even inject in ClassDataSources as properties to avoid repetitive constructors if you're using inheritance!
    [ClassDataSource<DataClass>(Shared = SharedType.PerTestSession)]
    public required DataClass DataClass { get; init; }

    #region Tests using Arguments coming from the class level

    [Test]
    public void ClassLevelDataRow()
    {
        Console.WriteLine(title);
        Console.WriteLine("Did I forget that data injection works on classes too?");
    }

    #endregion
}
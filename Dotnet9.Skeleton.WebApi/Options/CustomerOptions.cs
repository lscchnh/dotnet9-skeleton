using System.ComponentModel.DataAnnotations;

namespace Dotnet9.Skeleton.WebApi.Options;

public class CustomerOptions
{
    public const string Customer = "Customer";

    [Required(AllowEmptyStrings = false)]
    public string Company { get; set; } = string.Empty;
}

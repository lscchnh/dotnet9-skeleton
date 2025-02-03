var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Dotnet9_Skeleton_WebApi>("dotnet9-skeleton-api");

builder.Build().Run();

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// https://code-maze.com/aspnetcore-api-versioning/

builder.Services.AddApiVersioning(
    (ApiVersioningOptions opts) =>
    {
        opts.AssumeDefaultVersionWhenUnspecified = true;
        opts.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        // Shows actively supported API versions
        // Adds both 'api-supported-versions' and 'api-deprecated-versions' headers to our response
        opts.ReportApiVersions = true;
        // Supports different versioning schemes
        // Combines different ways of reading the API version (from a query string, request header, and media type)
        opts.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("X-Version"),
            new MediaTypeApiVersionReader("ver"));
    });
builder.Services.AddVersionedApiExplorer(
    (ApiExplorerOptions opts) =>
    {
        opts.GroupNameFormat = "'v'VVV"; // Formats the version as “'v'major[.minor][-status]”
        opts.SubstituteApiVersionInUrl = true; // Only necessary when versioning by the URI segment?
    });


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
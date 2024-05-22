using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Statistics.API.Tests.Integration.Fixtures;

public class WebApplicationFixture : WebApplicationFactory<Program>
{
    public Dictionary<string, string?> ConfigurationOverrides { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(ConfigurationOverrides)
            .Build();

        builder.UseConfiguration(configuration);
    }
}

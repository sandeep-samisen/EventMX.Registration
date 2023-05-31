using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EventMX.Registration.Application.IntegrationTests;

using static Testing;

internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            var integrationConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configurationBuilder.AddConfiguration(integrationConfig);
        });

        builder.ConfigureServices((builder, services) =>
        {
            services
                .Remove<ICurrentUserService>()
                .AddTransient(provider => Mock.Of<ICurrentUserService>(s =>
                    s.UserId == GetCurrentUserId()));
            if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services
                   .Remove<DbContextOptions<ApplicationDbContext>>()
                   .AddDbContext<ApplicationDbContext>((sp, options) =>
                       options.UseInMemoryDatabase("EventMX.RegistrationDb"));
            }
            else
            {
                services
                    .Remove<DbContextOptions<ApplicationDbContext>>()
                    .AddDbContext<ApplicationDbContext>((sp, options) =>
                        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"),
                            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
        });
    }
}

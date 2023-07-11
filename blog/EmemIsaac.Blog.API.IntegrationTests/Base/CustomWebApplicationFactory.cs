using EmemIsaac.Blog.Application;
using EmemIsaac.Blog.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace EmemIsaac.Blog.API.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<BlogDbContext>));

                if(dbContextDescriptor is not null)services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbConnection));

                if (dbConnectionDescriptor is not null)
                    services.Remove(dbConnectionDescriptor);

                // Create open SqliteConnection so EF won't automatically close it.
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<BlogDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                    //options.UseInMemoryDatabase("BlogDbContextInMemoryTest");
                });
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<BlogDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    try
                    {
                        //initialize db
                        context.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, $"An error occured while migrating the test db. Error: {e.Message}");
                    }
                    try
                    {
                        //initialize db
                        Utilities.InitializeTestDb(context);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, $"An error occured while seeding the test db. Error: {e.Message}");
                    }
                }
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}
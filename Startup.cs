using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Project_5.Project5.Models;

namespace Project_5
{
	public class Startup
	{
		public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		public Startup(IWebHostEnvironment env)
		{
			// Build configuration
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Configure DbContext options
			services.AddDbContext<Project_5Context>(options =>
				options.UseMySql(Configuration.GetConnectionString("Project_5ContextConnection"),
				new MariaDbServerVersion(new Version(10, 4, 27)), // Update the MariaDB version accordingly
				b => b.MigrationsAssembly("Project_5")));

			// Add other services to the dependency injection container
			// ...
		}

		
	}
}

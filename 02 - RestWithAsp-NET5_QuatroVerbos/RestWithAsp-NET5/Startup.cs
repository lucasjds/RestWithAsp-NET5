using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithAsp_NET5.Model.Context;
using RestWithAsp_NET5.Business;
using RestWithAsp_NET5.Business.Implementations;
using RestWithAsp_NET5.Repository;
using Serilog;
using System.Collections.Generic;
using RestWithAsp_NET5.Repository.Generic;

namespace RestWithAsp_NET5
{
  public class Startup
  {
    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;

      Log.Logger = new LoggerConfiguration()
                          .WriteTo.Console()
                          .CreateLogger();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
     
      services.AddControllers();
      var connection = Configuration["MySqlConnection:MySqlConnectionString"];
      services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
      if (Environment.IsDevelopment())
      {
        MigrateDatabase(connection);
      }
      services.AddApiVersioning();
      services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
      services.AddScoped<IBookBusiness, BookBusinessImplementation>();
      services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }

    private void MigrateDatabase(string connection)
    {
      try
      {
        var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
        var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
        {
          Locations = new List<string> { "db/migrations", "db/dataset" },
          IsEraseDisabled = true,
        };
        evolve.Migrate();
      }
      catch (System.Exception ex)
      {
        Log.Error("Database migration failed", ex);
        throw;
      }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using art_and_knights.Repositories;
using art_and_knights.Services;

namespace art_and_knights
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureCors(services);
      ConfigureAuth(services);
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "art_and_knights", Version = "v1" });
      });
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      // services.AddScoped<AccountsRepository>();
      // services.AddScoped<AccountService>();

      services.AddTransient<ArtistsRepository>();
      services.AddTransient<CastlesRepository>();

      services.AddTransient<ArtistsService>();
      services.AddTransient<CastlesService>();
    }

    private void ConfigureCors(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                      .WithOrigins(new string[]{
                        "http://localhost:8080", "http://localhost:8081"
                  });
              });
      });
    }

    private void ConfigureAuth(IServiceCollection services)
    {
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.Authority = $"https://{Configuration["AUTH0_DOMAIN"]}/";
        options.Audience = Configuration["AUTH0_AUDIENCE"];
      });

    }

    private IDbConnection CreateDbConnection()
    {
      string connectionString = Configuration["CONNECTION_STRING"];
      return new MySqlConnection(connectionString);
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "art_and_knights v1"));
        app.UseCors("CorsDevPolicy");
      }

      app.UseHttpsRedirection();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();


      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using To_Do_Lists.Data;

namespace To_Do_Lists
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      
      services.AddDbContext<ListDbContext>(builder =>
      {
        var connectionString = _configuration.GetConnectionString("ToDoListDB");
        builder.UseSqlServer(connectionString);
      });
      services.AddScoped<IToDoListRepository, ToDoListRepository>();

      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      services.AddControllers();
      
      services.AddMvc();
      
      //Register the Swagger generator, defining 1 or more Swagger documents
      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
        
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "To Do Lists Web API",
          Description = "A Web API for ToDoList Project ; which is used to help you organize and manage your tasks .",
        });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();
      
      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
      });
    }
  }
}

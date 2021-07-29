using System;
using System.Collections.Generic;
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

      //services.AddApiVersioning();
      /*
      services.AddApiVersioning(o =>
      {
        o.AssumeDefaultVersionWhenUnspecified=true;
        o.DefaultApiVersion = new ApiVersion(1, 1);
        
        o.ReportApiVersions = true;
        //this will add headers to the responses to say what API versions are going to be 
        //supported by a certain URI 
        
        //now it's
        //http://localhost:1234/api/camps?api-version=2.0
        //o.ApiVersionReader = new QueryStringApiVersionReader("ver");
        //after the line above , it is now :
        //http://localhost:1234/api/camps?ver=2.0

        //o.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        //after this line , we are now looking at the headers not the url
        
        //this line combines the two versioning methods(Version by header and version by Query string)
        o.ApiVersionReader = ApiVersionReader.Combine
        (new QueryStringApiVersionReader("ver", "version", "v"),
          new HeaderApiVersionReader("X-Version"));
        
      });*/

      
      services.AddMvc();
      
      //Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen();
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

using Aserto.AspNetCore.Middleware.Extensions;
using Aserto.AspNetCore.Middleware.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Authorization;
// using AutoMapper;


using Aserto.TodoApp.Domain.Repositories;
using Aserto.TodoApp.Domain.Services;
using Aserto.TodoApp.Persistence.Contexts;
using Aserto.TodoApp.Persistence.Repositories;
using Aserto.TodoApp.Services;
using Aserto.TodoApp.Configuration;

namespace Aserto.TodoApp
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

      string domain = $"https://{Configuration["OAuth:Domain"]}/";

      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseInMemoryDatabase("aserto-todo-app-in-memory");
      });

      services.AddScoped<ITodoRepository, TodoRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<ITodoService, TodoService>();
      services.AddScoped<IUserService, UserService>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
      {
        options.Authority = domain;
        options.Audience = Configuration["OAuth:Audience"];
      });

      //Aserto options handling
      services.AddAsertoAuthorization(options => Configuration.GetSection("Aserto").Bind(options));
      //end Aserto options handling

      services.Configure<AsertoConfig>(Configuration.GetSection("Aserto"));

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Aserto", policy => policy.Requirements.Add(new AsertoDecisionRequirement()));
      });

      // Only authorizes the endpoints that have the [Authorize("Aserto")] attribute
      services.AddControllers();

      services.AddAutoMapper(typeof(Startup).Assembly);

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

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        //// Authorizes all the endpoints. The below code is equivalent to decorating all endpoints with [Authorize("Aserto")] attribute
        //endpoints.MapControllers().RequireAuthorization("Aserto");
      });
    }
  }
}
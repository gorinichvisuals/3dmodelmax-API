using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Services;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using _3DModelMax.SQLPersistence;
using _3DModelMax.SQLPersistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnectionString");

        services.AddControllers();
        services.AddMvc();
        services.AddDbContext<AddDbContext>(contextOptions => contextOptions.UseSqlServer(connectionString));

        services.AddScoped<I3DModelRepository<_3DModel>, SQL3DModelsRepository>();
        services.AddScoped<IModelService, ModelService>();

        services.AddScoped<IAuthorRepository<Author>, SQLAuthorsRepository>();
        services.AddScoped<IAuthorService, AuthorService>();

        services.AddScoped<IImageRepository<Image>, SQLImagesRepository>();
        services.AddScoped<IImageService, ImageService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler();
            app.UseHsts();
        }

        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<AddDbContext>();
        //context.Database.EnsureCreated();
        //context.Database.Migrate();

        app.Run(async (context) => await context.Response.WriteAsync("Hello world"));
    }
}


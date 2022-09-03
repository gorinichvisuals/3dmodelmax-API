using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Services;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using _3DModelMax.SQLPersistence;
using _3DModelMax.SQLPersistence.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

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

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else 
        {
            app.UseExceptionHandler();
            app.UseHsts();
        }

        app.UseStatusCodePages();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<AddDbContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
        //app.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");
        app.Run(async (context) => await context.Response.WriteAsync("Could Not Find Anything"));
    }
}


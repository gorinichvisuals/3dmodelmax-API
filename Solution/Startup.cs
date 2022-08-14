using _3DModelMax.Host.Models;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public string ConnectionString { get; set; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<AppDBContext>(contextOptions => contextOptions.UseSqlServer(ConnectionString));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.UseStaticFiles();
    }
}


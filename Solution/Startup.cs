using _3DModelMax.Host.Models;
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
        var connectionString = "fake-db-connection";
        services.AddControllers();
        services.AddDbContext<AddDbContext>(contextOptions => contextOptions.UseSqlServer(connectionString));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
}


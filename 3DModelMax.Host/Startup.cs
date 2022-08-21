using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using _3DModelMax.SQLPersistence;
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
        // services.AddDbContext<AddDbContext>();
        services.AddScoped<IRepository<_3DModel>, SQL3DModelsRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using WebApplication1.Data;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                       optional: true,
                       reloadOnChange: true);
    config.AddEnvironmentVariables();
});

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")),
    ServiceLifetime.Transient,
    ServiceLifetime.Scoped
);

builder.Services.AddTransient<IAppContexto, AppContexto>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IVendedorService, VendedorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("corsapp");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using POC1.core.Delegates;
using POC1.core.Services;
using POC1.coreAPI.Delegates;
using POC1.coreAPI.Services;
using POC1.Entities1;
using POC1.Persistance1;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArtServices, ArtServices>();
builder.Services.AddScoped<IArtDelegates, ArtDelegates>();
builder.Services.AddScoped<IArtRepository, ArtRepository>();

var app = builder.Build();

// Enable Swagger only in Dev or explicitly in Azure
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

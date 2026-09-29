using Combine_Day_Sixteen_N_tier_API.Data;
using Combine_Day_Sixteen_N_tier_API.Repositories;
using Combine_Day_Sixteen_N_tier_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registering our AppDbContext with Dependancy Injection -> We use SQLite -> we're letting EF core Know we are using SQLite ->
// GEtting our connection string location -> and tells EF core where our database is.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Whenever
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

builder.Services.AddScoped<ISupplyServices, SupplyServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

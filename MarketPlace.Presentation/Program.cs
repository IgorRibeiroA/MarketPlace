using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Services;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Data;
using MarketPlace.Infrastructure.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DapperContext as a singleton
builder.Services.AddSingleton<DapperContext>();

// Registra IStoreService com StoreService
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

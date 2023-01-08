using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTask;
using MyTask.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var databaseName = builder.Configuration.GetConnectionString("NumberDatabaseName");

builder.Services.AddDbContext<ApiContext>(options => 
    options.UseInMemoryDatabase(databaseName));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<INumberRepository, NumberRepository>();

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

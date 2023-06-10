using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services;
using ProcessFlow.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ProcessDatabaseSettings>(builder.Configuration.GetSection("MongoDbConnection"));

builder.Services.AddSingleton<MongoContext>();
builder.Services.AddTransient<IAreaService, AreaService>();

builder.Services.AddControllers();
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

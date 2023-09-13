using Amazon.Util.Internal.PlatformServices;
using CasesControl.Database;
using CasesControl.Repository;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

var appSettings = new ApplicationSettings();
configuration.GetSection("ConnectionString").Bind(appSettings);
builder.Services.Configure<ApplicationSettings>(configuration.GetSection("ConnectionString"));

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(configuration.GetConnectionString("MongoDBConnection")));
builder.Services.AddScoped<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase("controleCasos"));

builder.Services.AddScoped<MongoDbConnector>();
builder.Services.AddScoped<CaseRepository>();
builder.Services.AddHttpContextAccessor();
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
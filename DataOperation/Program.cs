using Application;
using DataOperation.Middlewares;
using Infrastructure;
using Logging;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddTransient<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
builder.Services.AddTransient
(serviceType: typeof(Logging.ILogger<>),
    implementationType: typeof(Logging.NLogAdapter<>));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
        else
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod().AllowAnyHeader();
        }
    });
});

#region MySql
var host = Environment.GetEnvironmentVariable("MSSQL_HOST");
var port = Environment.GetEnvironmentVariable("MSSQL_PORT");
var db = Environment.GetEnvironmentVariable("MSSQL_DB");
var user = Environment.GetEnvironmentVariable("MSSQL_USER");
var pass = Environment.GetEnvironmentVariable("MSSQL_PASS");


var connectionString =
    $@"Server={host};Port={port}; Database={db}; Uid={user}; Pwd={pass}; Persist Security Info=true;Charset=utf8;";
builder.Services.AddDbContext<Infrustructure.DataBaseContext>(option => option.UseSqlServer(connectionString));
#endregion

var app = builder.Build();

app.UseRouting();

app.UseCors("CorsPolicy");

//app.UseMiddleware<LoggerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

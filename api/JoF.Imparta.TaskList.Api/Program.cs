using JoF.Imparta.TaskList.Api.Domain.Services;
using JoF.Imparta.TaskList.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddMvcBiuilderOptions();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApiServices();

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

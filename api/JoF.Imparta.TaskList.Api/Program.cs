using JoF.Imparta.TaskList.Api.Extensions;

var CorsName = "CorsLocalhost";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsName, policy =>
    {
        policy.WithOrigins("http://localhost:3030")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseCors(CorsName);

app.MapControllers();

app.Run();

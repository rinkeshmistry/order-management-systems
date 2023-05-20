using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Entities;
using OrderManagementApi.Common.ExtentionMethods;
using OrderManagementApi.Common.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register Database Context
builder.Services.AddDbContext<OrderManagementContext>();

// Logic to Register Dependencies 
builder.Services.RegisterServiceDependencies();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Management API", Version = "v1" });
    opt.OperationFilter<SwaggerUIMiddlewares>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configure Global Exceptions
app.UseMiddleware<ExceptionMiddleware>();

// Configure Global Exceptions
app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

// Logic to execute migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderManagementContext>();
    context.Database.Migrate();
}

app.Run();

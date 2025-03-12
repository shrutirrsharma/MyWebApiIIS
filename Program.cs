using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Register controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Register Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

//Enable swagger in all environment
app.UseSwagger();
app.UseSwaggerUI();

// Global Exception Handling Middleware (to log errors)
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthorization(); // ✅ Ensure Authorization Middleware is added
app.MapControllers(); // ✅ Enable controllers

app.Run();

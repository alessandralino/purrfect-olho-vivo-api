using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Configuration;
using purrfect_olho_vivo_api.Context;

var builder = WebApplication.CreateBuilder(args);
 
// Add dbcontext to the container
builder.Services.AddDbContexts(builder.Configuration);

// Add services to the container.

// Add services to the container.
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

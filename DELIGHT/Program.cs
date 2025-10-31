using DELIGHT.Core.Application.Extension;
using DELIGHT.Infraestructure.Persistence.Context;
using DELIGHT.Infraestructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure();
builder.Services.AddSqlServer<DELIGHTContext>(connectionString);
builder.Services.AddApplicationServices();

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

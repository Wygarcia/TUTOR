using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Repository;
using TUTOR.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connec = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<TutorDbContext>(options => options.UseSqlServer(connec));


builder.Services.AddScoped<IHistorialTipRepository, HistorialTipRepository>();
builder.Services.AddScoped<IHistorialTipService, HistorialTipService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permitir solicitudes desde cualquier origen
                   .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
                   .AllowAnyHeader(); // Permitir cualquier cabecera
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

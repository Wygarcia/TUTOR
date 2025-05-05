using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Repository;
using TUTOR.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de conexión a base de datos
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<TutorDbContext>(options =>
    options.UseSqlServer(connection));

// Registro de repositorios
builder.Services.AddScoped<IHistorialTipRepository, HistorialTipRepository>();
builder.Services.AddScoped<ITipRepository, TipRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registro de servicios
builder.Services.AddScoped<IHistorialTipService, HistorialTipService>();
builder.Services.AddScoped<ITipService, TipService>();
builder.Services.AddScoped<IUserService, UserService>();

// Habilitar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuración del middleware HTTP
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

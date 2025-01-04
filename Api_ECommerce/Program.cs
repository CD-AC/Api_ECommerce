using Api_ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Agrega el DbContext, especificando que use SQL Server y la cadena de conexi�n
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Agrega el servicio de controladores
builder.Services.AddControllers();

// 3. Agregar Swagger (opcional, recomendado para documentaci�n)
builder.Services.AddSwaggerGen();

// Configuraci�n final
var app = builder.Build();

// Secci�n de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

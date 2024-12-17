using Application.Services;
// using Infrastructure.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar dependencias
string excelPath = Path.Combine(Directory.GetCurrentDirectory(), "SchoolData.xlsx");
builder.Services.AddSingleton(new ExcelReader(excelPath));
builder.Services.AddScoped<MeetingService>();

// Configurar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

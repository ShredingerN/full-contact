using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Укажите путь к сгенерированному XML-файлу с комментариями
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}
);
//добавляет функционал для работы с контроллерами: сервис для обработки http-запросов, сервисы маршрутизации запросов к контроллерам и др.
builder.Services.AddControllers();
//внедрение зависимостей, если нужно что-то на уровне всего приложения, то:
builder.Services.AddSingleton<ContactStorage>();
//args[0] - означает, что теперь url передаем при запуске приложения
builder.Services.AddCors(opt => opt.AddPolicy(
    "AllowAll", policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(args[0]);
    }));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API V1");
});
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//добавляет функционал для работы с контроллерами: сервис для обработки http-запросов, сервисы маршрутизации запросов к контроллерам и др.
builder.Services.AddControllers();
//внедрение зависимостей, если нужно что-то на уровне всего приложения, то:
builder.Services.AddSingleton<ContactStorage>();
builder.Services.AddCors(opt => opt.AddPolicy(
    "AllowAll", policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:3000")));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();

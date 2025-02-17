using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
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
        services.AddControllers();
        //внедрение зависимостей, если нужно что-то на уровне всего приложения, то:
        var stringConnection = configuration.GetConnectionString("SqliteStringConnection");
        //настройка для базки без ef core
        // services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));
        services.AddScoped<IPaginationStorage, SqliteEfPaginationStorage>();
        services.AddDbContext<SqliteDbContext>(opt => opt.UseSqlite(stringConnection));
        services.AddScoped<IInitializer, SqliteEfFakerInitializer>();
                //args[0] - означает, что теперь url передаем при запуске приложения
                services.AddCors(opt => opt.AddPolicy(
                    "AllowAll", policy =>
                    {
                        policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        // добавили урл в настройки appsetings.Development.json
                        .WithOrigins(configuration["client"]);
                    }));

        return services;
    }
}


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCollection(builder.Configuration);


//middiware компоненты, настройка обработки запросов
var app = builder.Build();
app.Services.AddCustomerService(builder.Configuration);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API V1");
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToController("Index","Fallback");
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

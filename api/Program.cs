
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCollection(builder.Configuration);


var app = builder.Build();
app.Services.AddCustomerService(builder.Configuration);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API V1");
});
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

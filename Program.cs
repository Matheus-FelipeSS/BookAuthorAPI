using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Services.Autor;
using WebApi8.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IAutorinterface, AutorService>();
builder.Services.AddScoped<ILivroInterface, LivroService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

// Sempre exibe o Swagger, inclusive em produção
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi8-Video v1");
    c.RoutePrefix = string.Empty; // Swagger na raiz "/"
});

app.UseAuthorization();

app.MapControllers();

app.Run();



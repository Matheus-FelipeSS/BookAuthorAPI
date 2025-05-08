using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApi8.Data;
using WebApi8.Services.Autor;
using WebApi8.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

// Serviços
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

// Porta e IP para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Página HTML de boas-vindas na raiz
app.MapGet("/", () =>
    Results.Content(@"
        <!DOCTYPE html>
        <html lang='pt-br'>
        <head>
            <meta charset='UTF-8'>
            <title>API de Autores e Livros</title>
            <style>
                body {
                    background-color: #121212;
                    color: #f0f0f0;
                    font-family: Arial, sans-serif;
                    text-align: center;
                    padding-top: 100px;
                }
                h1 {
                    color: #4CAF50;
                }
            </style>
        </head>
        <body>
            <h1>API de Autores e Livros</h1>
            <p>A aplicação está funcionando corretamente!</p>
        </body>
        </html>
    ", "text/html", Encoding.UTF8)
);

app.Run();


using Microsoft.EntityFrameworkCore;
using Test2CreateApi.Context;
using Test2CreateApi.Scripts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// TODO: Swagger ya no viene por defecto en .net 10 por que microsoft prefiere utilizar OpenApi debido a que 
//  Swagger no tiene mucho mantenimiento

// TODO: Se crea una variable para una cadena de conexion
//  Nota: en "Connection" va es el nombre que colocaste en el appsetting.json (paso5) en mi caso fue ese

var connectionString = builder.Configuration.GetConnectionString("Connection");

// TODO: Agregamos el DbContext (es el servicio par ala conexion. dentro del <> colocamos el nombre de nuestro context
//  En mi caso es AppDbContext
//  Lo que dice UseSqlServer es el motor de nuestra Db
//  Y por ultimo lo que esta dentro de los parentesis que dice connectionString es nuestra cadena de conexion declarada
//   Anteriormente
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers(); // La app reconocera y gestionará los controladores que respondan a las solicitudes http
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Se registra el servicio que se encarga de generar la documentacion de OpenApi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Verifica la app esta en un entorno de desarrollo, si es asi habilita OpenApi (segun entiendo)
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); // Se agrega el middleware para redirigir las solicitudes http a https
// TODO: Un middleware es un software que actua como un puente facilitando la comunicacion entre, apps, db, redes, etc.

app.UseAuthorization(); // Se agrega middleware para habilitar la autorizacion en la app

app.MapControllers(); // Se asignan las rutas de los controladores para que la app pueda dirigir las solicitudes http a los controladores

app.Run(); // Inicia la app

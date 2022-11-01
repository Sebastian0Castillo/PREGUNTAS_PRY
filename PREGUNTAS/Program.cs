global using Microsoft.EntityFrameworkCore;
using PREGUNTAS.Interfaces;
using PREGUNTAS.Maps;
using PREGUNTAS.DataLayer.DB.Context;
using PREGUNTAS.Services;
using PREGUNTAS.Interfaces.Preguntas_respuestas;
using PREGUNTAS.Services.Preguntas_Respuestas;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de automapeo
builder.Services.AddAutoMapper(typeof(MapperMap));

builder.Services.AddSingleton<IUtilitiesService, UtilitiesService>();

builder.Services.AddScoped<IpreguntasService, PreguntasService>();

builder.Services.AddDbContext<DB>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

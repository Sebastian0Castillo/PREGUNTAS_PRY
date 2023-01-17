global using Microsoft.EntityFrameworkCore;
using PREGUNTAS.Interfaces;
using PREGUNTAS.Maps;
using PREGUNTAS.DataLayer.DB.Context;
using PREGUNTAS.Services;
using PREGUNTAS.Interfaces.Preguntas_respuestas;
using PREGUNTAS.Services.Preguntas_Respuestas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Routing.Matching;
using PREGUNTAS.Interfaces.Authorization;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Inyección de automapeo
builder.Services.AddAutoMapper(typeof(MapperMap));

builder.Services.AddSingleton<IUtilitiesService, UtilitiesService>();
builder.Services.AddScoped<IRespuestasService, RespuestasService>();
builder.Services.AddScoped<IpreguntasService, PreguntasService>();
builder.Services.AddSingleton<IAuthorizationHandler, Custom_AuthHandler>();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "v1", Version = "v1" });

    opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header
    });

    opt.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] {}
        }
    });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration.GetSection("AppSettings:Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("AppSettings:Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Jwt:Key").Value)),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true
    };
});

builder.Services.AddAuthorization(el =>
{
    el.AddPolicy("Otros", policy => policy.Requirements.Add(new Custom_AtuhAttribute()));
});

builder.Services.AddDbContext<DB>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using LC_DEQ.Models.BaseDeDatos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>    //es para configurar la seguridad del cliente de pruebas
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "api_DEQ", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

// obtenemos cadena de conexion de appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

//se configura dbcontext para modelo de datos
builder.Services.AddDbContext<BDContext_DEQ>(options =>
{//se espesifica que tipo de coneccion va a ser, en este caso es postgress
    //conexionString = cadena de conexion 
    //migrations assembly= es donde se genera la carpeta de migraciones
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("LC_DEQ"));

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( // esta configuracion es la del token, se tiene que tener igual que el login
               options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "192.168.0.10",
                    ValidAudience = "192.168.0.10",
                    IssuerSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes("***Osvaldo.141197***")),//Configuration["Llave"])),
                    ClockSkew = TimeSpan.Zero
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

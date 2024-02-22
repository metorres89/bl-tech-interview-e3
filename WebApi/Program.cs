using BlTechInterviewE3.Data.Mapper;
using BlTechInterviewE3.Data.Utils;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Service.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
                 //.SetBasePath(Directory.GetCurrentDirectory())
                 //.AddJsonFile("appsettings.json")
                 .AddEnvironmentVariables()
                 .Build();

builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddScoped<IDbConnectionFactory, NpgsqlConnectionFactory>(serviceProvider => {
    return new NpgsqlConnectionFactory(Environment.GetEnvironmentVariable("APP_CONNECTION_STRING") ?? string.Empty);
});
builder.Services.AddScoped<IUserDataMapper, UserDataMapper>();
builder.Services.AddScoped<IDataMapper<Book>, BookDataMapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();

// Add JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["APP_JWT_ISSUER"],
        ValidAudience = config["APP_JWT_AUDIENCE"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["APP_JWT_SECRET_KEY"]))
    };
});

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book WebApi", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the JWT token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    };

    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

bool enableHttpsRedirection;
bool parsed = bool.TryParse(Environment.GetEnvironmentVariable("APP_ENABLE_HTTPS_REDIRECTION"), out enableHttpsRedirection);

if(parsed && enableHttpsRedirection)
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
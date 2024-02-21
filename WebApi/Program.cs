using BlTechInterviewE3.Data.Mapper;
using BlTechInterviewE3.Data.Utils;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Service.Contract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory, NpgsqlConnectionFactory>(serviceProvider => {
    return new NpgsqlConnectionFactory(Environment.GetEnvironmentVariable("APP_CONNECTION_STRING") ?? string.Empty);
});
builder.Services.AddScoped<IDataMapper<Book>, BookDataMapper>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
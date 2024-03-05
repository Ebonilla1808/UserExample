using UserExample.Data;
using Microsoft.EntityFrameworkCore;
using UserExample.Repository;
using UserExample.Data.Repository.SqlServer;
using System.Text.Json.Serialization;
using UserExample.Model;
using System.Text.Json;
using UserExample.Data.Repository.LocalList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<UserExampleContext>(o =>
{
    o.UseSqlServer(connectionString);
});

//ruta del archivo y la lista de roles desde la configuración
string filePathRole = builder.Configuration.GetValue<string>("FilePathRole");

// Deserializa los roles desde el archivo JSON
List<Role> roles = GetEntities<Role>(filePathRole);

// Inyecta la ruta del archivo y la lista de roles en los servicios
builder.Services.AddSingleton(filePathRole);
builder.Services.AddSingleton(roles);

//ruta del archivo y la lista de roles desde la configuración
string filePathUser = builder.Configuration.GetValue<string>("FilePathRole");


builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UserExampleContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

 static List<T> GetEntities<T>(string filePath)
{
    List<T> entities;
    if (File.Exists(filePath))
    {
        var json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        entities = JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
    }
    else
    {
        entities = new List<T>();
    }

    return entities;
}


using Footest.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var hostName = System.Net.Dns.GetHostName();
Console.WriteLine($"Hostname: {hostName}" );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () =>
{
    // Имя сервиса
    var serviceName = "Footest.Service";

    // Имя хоста
    var hostName = System.Net.Dns.GetHostName();

    // Возвращаем JSON с информацией
    return Results.Json(new
    {
        ServiceName = serviceName,
        HostName = hostName
    });
});

app.MapGet("/utcNow", () => DateTime.UtcNow);



app.Run();
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using GestaoMicroestrutural.Domain.Repositories;
using GestaoMicroestrutural.Infrastructure.EventStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GestaoMicroestrutural.Api",
        Version = "v1"
    });
});

// Habilita o uso de Controllers tradicionais da API
builder.Services.AddControllers();

// Adiciona o MediatR escanenando o Assembly da camada Application
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GestaoMicroestrutural.Application.AssemblyReference).Assembly));

// Injeção do EF Core
builder.Services.AddDbContext<EventStoreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção do Repositório
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestaoMicroestrutural.Api v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

// Mapeia as rotas para as Controllers

app.MapControllers();
app.MapGet("/", (IWebHostEnvironment env) => new 
{ 
    Mensagem = "API Gestão Microestrutural está Online!",
    AmbienteAtual = env.EnvironmentName 
});

app.Run();

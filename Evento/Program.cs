using Evento.Repositories;
using Evento.Repositories.Interfaces;
using Evento.Services.Cadastro;
using MySql.Data.MySqlClient;
using System.Data;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string CORS_POLICY = "MyPolicy";
// CONFIGURAÇÕES
builder.Services.AddCors(o => o.AddPolicy(CORS_POLICY, builder =>
{
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();

    // U Can Filter Here
}));

builder.Services.AddScoped<IDbConnection>(s =>
{
    return new MySqlConnection(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddScoped<IEventoCadastroService, EventoCadastroService>();
builder.Services.AddScoped<IEVENTOS_REPOSITORY, EVENTOS_REPOSITORY>();

var app = builder.Build();
app.UseCors(CORS_POLICY);

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

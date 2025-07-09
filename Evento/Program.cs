using Evento.Repositories;
using Evento.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using FluentValidation;
using Evento.Services.Evento.Cadastro;
using Evento.Services.Evento.Presenca;
using Evento.Services.Pessoa;
using Evento.Services.EventoPessoa;

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
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IEventoPessoaService, EventoPessoaService>();
builder.Services.AddScoped<IConfirmarPresencaService, ConfirmarPresencaService>();
builder.Services.AddScoped<IPESSOAS_REPOSITORY, PESSOAS_REPOSITORY>();
builder.Services.AddScoped<IEVENTOS_PESSOAS_REPOSITORY, EVENTOS_PESSOAS_REPOSITORY>();
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

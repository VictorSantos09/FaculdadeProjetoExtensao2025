using Evento.Repositories;
using Evento.Repositories.Interfaces;
using Evento.Services.Evento.Cadastro;
using Evento.Services.Evento.Presenca;
using Evento.Services.EventoPessoa;
using Evento.Services.Pessoa;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

namespace Evento.Core.Configuration;
public static class EventoConfig
{
    public static IServiceCollection AddEventoCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(s =>
        {
            return new MySqlConnection(configuration.GetConnectionString("Default"));
        });

        services.AddValidatorsFromAssembly(typeof(EventoConfig).Assembly);

        services.AddScoped<IEventoCadastroService, EventoCadastroService>();
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IEventoPessoaService, EventoPessoaService>();
        services.AddScoped<IConfirmarPresencaService, ConfirmarPresencaService>();
        services.AddScoped<IPESSOAS_REPOSITORY, PESSOAS_REPOSITORY>();
        services.AddScoped<IEVENTOS_PESSOAS_REPOSITORY, EVENTOS_PESSOAS_REPOSITORY>();
        services.AddScoped<IEVENTOS_REPOSITORY, EVENTOS_REPOSITORY>();

        return services;
    }
}

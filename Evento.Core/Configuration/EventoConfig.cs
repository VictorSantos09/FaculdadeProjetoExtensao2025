using Evento.Core.Repositories;
using Evento.Core.Repositories.Interfaces;
using Evento.Core.Services.Evento.Cadastro;
using Evento.Core.Services.Evento.Presenca;
using Evento.Core.Services.EventoPessoa;
using Evento.Core.Services.Pessoa;
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

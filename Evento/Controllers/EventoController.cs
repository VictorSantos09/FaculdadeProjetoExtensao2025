using Evento.Repositories.Interfaces;
using Evento.Services.Cadastro;
using Evento.Services.Presenca;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Controllers;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase
{
    private readonly IEventoCadastroService _eventoCadastroService;
    private readonly IConfirmarPresencaService _confirmarPresencaService;    
    private readonly IEVENTOS_REPOSITORY _eventos_repository;

    public EventoController(IEventoCadastroService eventoCadastroService,
                            IEVENTOS_REPOSITORY eventos_repository,
                            IConfirmarPresencaService confirmarPresencaService)
    {
        _eventoCadastroService = eventoCadastroService;
        _eventos_repository = eventos_repository;
        _confirmarPresencaService = confirmarPresencaService;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(EventoCadastroDTO dto)
    {
        var result = await _eventoCadastroService.CadastrarAsync(dto);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _eventos_repository.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetyId(int id)
    {
        var result = await _eventos_repository.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }
    [HttpDelete]
    public async Task <IActionResult> Deletar(int id)
    {
        await _eventos_repository.DeleteAsync(id);
        return Ok();
    }
    [HttpPut("confirmarPresenca")]
    public async Task<IActionResult> GetQRCode(ConfirmarPresencaDTO dto)
    {
        var result = await _confirmarPresencaService.ConfirmarAsync(dto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}

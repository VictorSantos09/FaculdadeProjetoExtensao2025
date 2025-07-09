using Evento.Entities;
using Evento.Services.EventoPessoa;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Controllers;

[ApiController]
[Route("eventos-pessoas")]
public class EventoPessoaController(IEventoPessoaService eventoPessoaService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var eventosPessoas = await eventoPessoaService.GetAllAsync();
        return Ok(eventosPessoas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var eventoPessoa = await eventoPessoaService.GetByIdAsync(id);
        return eventoPessoa is not null ? Ok(eventoPessoa) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EVENTOS_PESSOAS eventoPessoa)
    {
        if (eventoPessoa is null)
        {
            return BadRequest("EventoPessoa não pode ser nulo.");
        }
        await eventoPessoaService.CreateAsync(eventoPessoa);
        return CreatedAtAction(nameof(GetById), new { id = eventoPessoa.ID }, eventoPessoa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EVENTOS_PESSOAS eventoPessoa)
    {
        if (eventoPessoa is null || eventoPessoa.ID != id)
        {
            return BadRequest("Dados inválidos para atualização.");
        }
        var existingEventoPessoa = await eventoPessoaService.GetByIdAsync(id);
        if (existingEventoPessoa is null)
        {
            return NotFound();
        }
        await eventoPessoaService.UpdateAsync(eventoPessoa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingEventoPessoa = await eventoPessoaService.GetByIdAsync(id);
        if (existingEventoPessoa is null)
        {
            return NotFound();
        }
        await eventoPessoaService.DeleteAsync(id);
        return NoContent();
    }
}

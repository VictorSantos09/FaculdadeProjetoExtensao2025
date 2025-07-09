using Evento.Entities;
using Evento.Services.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Controllers;

[ApiController]
[Route("pessoas")]
public class PessoaController(IPessoaService pessoaService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pessoas = await pessoaService.GetAllAsync();
        return Ok(pessoas);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pessoa = await pessoaService.GetByIdAsync(id);
        return pessoa is not null ? Ok(pessoa) : NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PESSOAS pessoa)
    {
        if (pessoa is null)
        {
            return BadRequest("Pessoa não pode ser nula.");
        }
        await pessoaService.CreateAsync(pessoa);
        return CreatedAtAction(nameof(GetById), new { id = pessoa.ID }, pessoa);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PESSOAS pessoa)
    {
        if (pessoa is null || pessoa.ID != id)
        {
            return BadRequest("Dados inválidos para atualização.");
        }
        var existingPessoa = await pessoaService.GetByIdAsync(id);
        if (existingPessoa is null)
        {
            return NotFound();
        }
        await pessoaService.UpdateAsync(pessoa);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingPessoa = await pessoaService.GetByIdAsync(id);
        if (existingPessoa is null)
        {
            return NotFound();
        }
        await pessoaService.DeleteAsync(id);
        return NoContent();
    }
}

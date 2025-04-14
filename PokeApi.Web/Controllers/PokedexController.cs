using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Interfaces;
using PokeApi.Domain.Entities;

namespace PokeApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly IPokedexService _pokedexService;

        public PokedexController(IPokedexService pokedexService)
        {
            _pokedexService = pokedexService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokedexService.GetAllAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pokemon = await _pokedexService.GetByIdAsync(id);
            if (pokemon == null) return NotFound();
            return Ok(pokemon);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Pokemon pokemon)
        {
            var result = await _pokedexService.CreateAsync(pokemon);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Pokemon pokemon)
        {
            if (id != pokemon.Id) return BadRequest("ID mismatch");

            var updated = await _pokedexService.UpdateAsync(pokemon);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _pokedexService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

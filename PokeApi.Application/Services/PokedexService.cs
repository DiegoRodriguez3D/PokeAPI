using PokeApi.Application.Interfaces;
using PokeApi.Domain.Entities;

namespace PokeApi.Application.Services
{
    public class PokedexService : IPokedexService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokedexService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await _pokemonRepository.GetAllAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _pokemonRepository.GetByIdAsync(id);
        }

        public async Task<Pokemon> CreateAsync(Pokemon pokemon)
        {
            return await _pokemonRepository.CreateAsync(pokemon);
        }

        public async Task<Pokemon> UpdateAsync(Pokemon pokemon)
        {
            return await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _pokemonRepository.DeleteAsync(id);
        }
    }
}

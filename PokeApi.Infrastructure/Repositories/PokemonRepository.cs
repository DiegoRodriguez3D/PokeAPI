using Microsoft.EntityFrameworkCore;
using PokeApi.Application.Interfaces;
using PokeApi.Domain.Entities;
using PokeApi.Infrastructure.Data;

namespace PokeApi.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _db;

        public PokemonRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await _db.Pokemons.ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _db.Pokemons.FindAsync(id);
        }

        public async Task<Pokemon> CreateAsync(Pokemon pokemon)
        {
            _db.Pokemons.Add(pokemon);
            await _db.SaveChangesAsync();
            return pokemon;
        }

        public async Task<Pokemon> UpdateAsync(Pokemon pokemon)
        {
            _db.Pokemons.Update(pokemon);
            await _db.SaveChangesAsync();
            return pokemon;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Pokemons.FindAsync(id);
            if (existing == null) return false;

            _db.Pokemons.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

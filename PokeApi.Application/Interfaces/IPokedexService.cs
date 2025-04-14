using PokeApi.Domain.Entities;

namespace PokeApi.Application.Interfaces
{
    public interface IPokedexService
    {
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(int id);

        Task<Pokemon> CreateAsync(Pokemon pokemon);
        Task<Pokemon> UpdateAsync(Pokemon pokemon);
        Task<bool> DeleteAsync(int id);
    }
}

namespace PokeApi.Domain.Entities
{
    public class TeamPokemon
    {
        public int Id { get; set; }

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}

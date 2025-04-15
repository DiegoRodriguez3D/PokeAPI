namespace PokeApi.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string? Type2 { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int HP { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public int? EvolvesFromId { get; set; }
        public Pokemon? EvolvesFrom { get; set; }

        public int? EvolvesToId { get; set; }
        public Pokemon? EvolvesTo { get; set; }

        public ICollection<TeamPokemon> TeamPokemons { get; set; } = new List<TeamPokemon>();
    }
}

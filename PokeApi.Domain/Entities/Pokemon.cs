namespace PokeApi.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // En la primera generación algunos Pokémon tienen 1 o 2 tipos.
        public string Type1 { get; set; }
        public string Type2 { get; set; }  // puede ser null si solo tiene 1 tipo

        // Ejemplo de estadísticas
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int HP { get; set; }

        public string Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        // Relación Muchos a Muchos con Team (a través de TeamPokemon)
        public ICollection<TeamPokemon> TeamPokemons { get; set; }
            = new List<TeamPokemon>();
    }
}

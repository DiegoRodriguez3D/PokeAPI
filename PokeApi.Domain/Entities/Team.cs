namespace PokeApi.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }

        // A quién pertenece este equipo (IdentityUser)
        // Guardaremos la referencia por string (UserId) o Guid
        // porque IdentityUser usa normalmente string (GUID) como PK por defecto.
        public string UserId { get; set; }

        // Relación con la tabla intermedia
        public ICollection<TeamPokemon> TeamPokemons { get; set; }
            = new List<TeamPokemon>();
    }
}

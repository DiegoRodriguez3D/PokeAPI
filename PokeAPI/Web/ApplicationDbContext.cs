using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PokeApi.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí iremos agregando los DbSet de nuestras entidades.
        // Por ejemplo:
        // public DbSet<Pokemon> Pokemons { get; set; }
        // public DbSet<Team> Teams { get; set; }
    }
}

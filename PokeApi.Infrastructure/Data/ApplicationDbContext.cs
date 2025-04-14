using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokeApi.Domain.Entities;

namespace PokeApi.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPokemon> TeamPokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamPokemon>()
                .HasOne(tp => tp.Pokemon)
                .WithMany(p => p.TeamPokemons)
                .HasForeignKey(tp => tp.PokemonId);

            builder.Entity<TeamPokemon>()
                .HasOne(tp => tp.Team)
                .WithMany(t => t.TeamPokemons)
                .HasForeignKey(tp => tp.TeamId);

        }
    }
}

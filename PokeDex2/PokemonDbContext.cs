namespace PokeDex2
{
    using Microsoft.EntityFrameworkCore;
    using PokeDex2.Models;
    using System;
    using System.Collections.Generic;

    public class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<FavoritePokemon> FavoritePokemons { get; set; }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }


    }
}

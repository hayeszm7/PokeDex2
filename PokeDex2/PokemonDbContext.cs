namespace PokeDex2
{
    using Microsoft.EntityFrameworkCore;
    using PokeDex2.Models;
    using System;
    using System.Collections.Generic;

    public class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        

        public string DbPath { get; }

        public PokemonDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "pokemon.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

   
}

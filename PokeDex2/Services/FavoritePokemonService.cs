using Microsoft.EntityFrameworkCore;
using PokeDex2.Models;

namespace PokeDex2.Services
{
    public class FavoritePokemonService
    {
        private readonly PokemonDbContext _context;

        public FavoritePokemonService(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToFavorites(int pokemonId)
        {
            try
            {
                var pokemon = await _context.Pokemon.FindAsync(pokemonId);
                if (pokemon == null)
                {
                    return false; // Pokemon not found
                }

                var favorite = new FavoritePokemon
                {
                    PokemonId = pokemonId,
                    PokemonName = pokemon.name,
                };

                _context.FavoritePokemons.Add(favorite);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle database errors
                return false;
            }
        }

        public async Task<List<FavoritePokemon>> GetFavoritePokemons()
        {
            return await _context.FavoritePokemons.ToListAsync();
        }
    }
}

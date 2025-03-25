namespace PokeDex2
{
    using Microsoft.EntityFrameworkCore;
    using PokeDex2.API;

    public class PokemonDataService
    {
        private readonly PokemonDbContext _dbContext;
        private readonly ApiClient _pokeApiClient; // Your PokeAPI client

        public PokemonDataService(PokemonDbContext dbContext, ApiClient pokeApiClient)
        {
            _dbContext = dbContext;
            _pokeApiClient = pokeApiClient;
        }

        public async Task PopulateDatabase(int startId, int endId)
        {
            for (int i = startId; i <= endId; i++)
            {
                try
                {
                    var pokemon = await _pokeApiClient.GetPokemonById(i.ToString());
                    if (pokemon != null)
                    {
                        _dbContext.Pokemon.Add(pokemon);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching Pokemon {i}: {ex.Message}");
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}

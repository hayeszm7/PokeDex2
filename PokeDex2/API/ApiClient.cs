
using Microsoft.EntityFrameworkCore;
using PokeDex2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeDex2.API
{
    public class ApiClient
    {
        public HttpClient Client { get; set; }
        public ApiClient(HttpClient client)
        {
            Client = client;
        }
        public PokemonDbContext _dbContext;

        public async Task<Pokemon> GetPokemonById(string id)

        {

            var response = await Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pokemon>(content);
        }
        public async Task<List<Pokemon>> GetAllPokemon(int startId, int endId)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();

            for (int i = 1; i <= 1302; i++)
            {
                try
                {
                    Pokemon pokemon = await GetPokemonById(i.ToString());
                    if (pokemon != null)
                    {
                        pokemonList.Add(pokemon);

                        // Add to database
                        _dbContext.Pokemon.Add(pokemon);
                        await _dbContext.SaveChangesAsync(); // Save changes to the database
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching Pokemon {i}: {ex.Message}");
                }
            }

            return pokemonList;
        }

        
    }
}


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
        


        public  async Task<List<Pokemon>> GetAllPokemon()
            
        {
            List<Pokemon> allPokemon = new List<Pokemon>();
            string url = "https://pokeapi.co/api/v2/pokemon?limit=151"; // Start with a limit

            while (url != null)
            {
                try
                {
                    string json = await Client.GetStringAsync(url);
                    PokemonListResponse response = JsonSerializer.Deserialize<PokemonListResponse>(json);

                    if (response?.Results != null)
                    {
                        allPokemon.AddRange((IEnumerable<Pokemon>)response.Results);
                    }

                    url = response?.Next; // Get the next page URL
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                    break; // Stop if there's an error
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error parsing JSON: {ex.Message}");
                    break;
                }
            }
            
           return allPokemon;
        }
        
        public async Task<Pokemon> GetPokemonById(string id)

        {
            var response = await Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pokemon>(content);
        }
    }
}

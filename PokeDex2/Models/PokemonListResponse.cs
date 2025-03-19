namespace PokeDex2.Models
{
    public class PokemonListResponse
    {
        public List<PokemonResult> Results { get; set; }
        public string Next { get; set; } // For pagination
    }
}

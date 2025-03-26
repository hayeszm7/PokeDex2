using System.ComponentModel.DataAnnotations;

namespace PokeDex2.Models
{
    public class FavoritePokemon
    {
        
        public int FavoriteId { get; set; }
        public int PokemonId { get; set; }
        public string PokemonName { get; set; } //Store the name, so the pokemon can be displayed even if the original pokemon entry is deleted.
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        // Navigation property (optional, for EF Core relationships)
        public Pokemon Pokemon { get; set; }
    }
}

namespace GameStore.Models
{
    public class Shop
    {
        public IEnumerable<Game> FeaturedGames { get; set; }
        public IEnumerable<Game> Games { get; set; }
     }
}

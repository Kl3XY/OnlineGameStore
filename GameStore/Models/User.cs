namespace GameStore.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Game> OwnedGames { get; set; }
    }
}

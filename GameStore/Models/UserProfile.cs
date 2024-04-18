namespace GameStore.Models
{
    public class UserProfile
    {
        public User user {  get; set; }
        public List<Game> library {  get; set; }
    }
}

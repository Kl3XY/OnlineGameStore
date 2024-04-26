namespace GameStore.Models
{
    public class Friend
    {
        public int userID { get; set; }
        public User user { get; set; }

        public int? chatID { get; set; }
        public Chat chat { get; set; }
    }
}

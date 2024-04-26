namespace GameStore.Models
{
    public class Message
    {
        public int chatID { get; set; }
        public Chat chat { get; set; }
        public int userID { get; set; }
        public string message { get; set; }
    }
}

namespace GameStore.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int user1Id { get; set; }
        public int user2Id { get; set; }
        public DateTime dateTime { get; set; }
        public string message { get; set; }
    }
}

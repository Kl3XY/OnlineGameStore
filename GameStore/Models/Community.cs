namespace GameStore.Models
{
    public class Community
    {
        public int ID {  get; set; }
        public int userID {  get; set; }
        public int gameID {  get; set; }
        public string message { get; set; }
        public Community comments { get; set; }
        public Game game { get; set; }
        public User user { get; set; }
    }
}

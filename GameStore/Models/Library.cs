namespace GameStore.Models
{
    public class Library
    {
        public int gameID { get; set; }
        public int userID { get; set; }

        public Game game { get; set; }
    }
}

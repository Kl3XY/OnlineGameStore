namespace GameStore.Models
{
    public class Reply
    {
        public int ID { get; set; }
        public int communityPostID { get; set; }
        public int userID { get; set; }
        public string message { get; set; }

        public Community comment { get; set; }
    }
}

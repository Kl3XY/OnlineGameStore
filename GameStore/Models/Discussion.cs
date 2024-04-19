namespace GameStore.Models
{
    public class Discussion
    {
        public string communityPostID { get; set; }
        public Community community { get; set;}
        public string ReplyMessage { get; set;}
    }
}

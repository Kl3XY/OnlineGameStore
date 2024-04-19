namespace GameStore.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public string Message { get; set; }

        public int communityID { get; set; }
        public Community community { get; set; }
    }
}
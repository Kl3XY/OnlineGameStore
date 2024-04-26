using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public string Message { get; set; }

        public int? UserID { get; set; }
        
        public int communityID { get; set; }
        public Community community { get; set; }
        public User User { get; set; }
    }
}
using GameStore.Models;

namespace GameStore.ViewModels
{
    public class openDiscussionModel
    {
        public Community community { get; set; }
        public List<Comments> comments {  get; set; }

        public string newReply { get; set; }
    }
}

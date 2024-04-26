using GameStore.Models;

namespace GameStore.ViewModels
{
    public class openChatModel
    {
        public int userID {  get; set; }
        public User user { get; set; }
        public int user2ID {  get; set; }
        public User user2 { get; set; }
        public List<Chat> chats { get; set; }
    }
}

namespace GameStore.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
        public bool isFeatured { get; set; }
    }
}

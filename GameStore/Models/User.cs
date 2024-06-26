﻿namespace GameStore.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int funds { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Library> Library { get; set; }
    }
}

using GameStore.Models;

namespace GameStore.Data
{
    public static class DbInit
    {
        public static void Init(DatabaseContext context) 
        {
        
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{Name="Kl3XY", Password="helloWorld1"},
                new User{Name="User1", Password="thisisapassword"},
                new User{Name="Dooms", Password="12345"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var games = new Game[]
            {
                new Game{Title="Almighty Shield", Description="Looter Action RPG.", price=7.99f},
                new Game{Title="Gorbino's Quest", Description="500 Hours of Mind Pumping Action", price=999.99f},
                new Game{Title="Godstone", Description="Roguelike RPG", price=9.99f},
                new Game{Title="Game to own", Description="this is a game you should own", price=19.99f}
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}

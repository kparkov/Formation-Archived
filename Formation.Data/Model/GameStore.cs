using System.Data.Entity;

namespace Formation.Data.Model
{
    public class GameStore : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
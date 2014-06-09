using System.Collections.Generic;
using System.Linq;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class Game : BaseModel
	{
		public virtual ICollection<Player> Players { get; set; } 
		public virtual ICollection<GameState> GameStates { get; set; }
		public virtual ICollection<Move> Moves { get; set; }

		public Game()
		{
			GameStates = new List<GameState>();
			Moves = new List<Move>();
			Players = new List<Player>();
		}

		public Game(Player white, Player black) : this()
		{
			Players.Add(white);
			Players.Add(black);
		}

		public GameState CurrentState
		{
			get { return GameStates.Last(); }
		}

		public Player White
		{
			get { return Players.ToList()[0]; }
		}

		public Player Black
		{
			get { return Players.ToList()[1]; }
		}


	}
}
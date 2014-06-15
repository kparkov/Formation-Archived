using System.Collections.Generic;
using System.Linq;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class Game : BaseModel
	{
		public virtual Player White { get; set; } 
		public virtual Player Black { get; set; }
		public virtual ICollection<GameState> GameStates { get; set; }
		public virtual ICollection<Move> Moves { get; set; }

		public Game()
		{
			GameStates = new List<GameState>();
			Moves = new List<Move>();
		}

		public GameState CurrentState
		{
			get { return GameStates.Last(); }
		}
	}
}
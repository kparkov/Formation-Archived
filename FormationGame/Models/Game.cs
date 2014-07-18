using System;
using System.Collections.Generic;
using System.Linq;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class Game : BaseModel
	{
		public virtual Player White { get; set; }
		public virtual Player Black { get; set; }

		private Player _firstActingPlayer;

		public virtual Player FirstActingPlayer
		{
			get
			{
				return _firstActingPlayer;
			}
			set
			{
				if (_firstActingPlayer != null && (_firstActingPlayer == White || _firstActingPlayer == Black))
				{
					_firstActingPlayer = value;
				}

				throw new ArgumentException("The first acting player must be one of the registered players.");
			}
		}

		public virtual List<GameState> GameStates { get; set; }
		public virtual List<Move> Moves { get; set; }

		public Game()
		{
			GameStates = new List<GameState>();
			Moves = new List<Move>();
		}

		/// <summary>
		/// The current state of the game, or null if none.
		/// </summary>
		public GameState CurrentState
		{
			get
			{
				if (!GameStates.Any())
				{
					return null;
				}
				
				return GameStates.Last();
			}
		}

		/// <summary>
		/// Given a player, returns the other player in this game.
		/// </summary>
		/// <param name="currentPlayer"></param>
		/// <returns></returns>
		public Player GetOpposingPlayer(Player currentPlayer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Tells us whether all criteria are upheld for this game to be in a valid state.
		/// </summary>
		/// <returns>True if valid, false if invalid</returns>
		public bool IsValidAndReady()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// A static method to return a new, valid game with the necessary objects.
		/// </summary>
		/// <returns>A game object</returns>
		public static Game GetNewGame(Player white, Player black)
		{
			// todo: get a valid new game, ready for playing

			return new Game();
		}

		public override string ToString()
		{
			return String.Format("[GAME]: {0} (white) against {1} (black). Game state # {2}", White, Black, GameStates.Count);
		}
	}
}
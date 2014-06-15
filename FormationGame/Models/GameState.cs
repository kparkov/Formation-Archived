using System;
using System.Linq;
using BitFrame.Models;
using Newtonsoft.Json;

namespace FormationGame.Models
{
	public class GameState : BaseModel
	{
		[JsonIgnore]
		public virtual Game Game { get; set; }

		/// <summary>
		/// Returns the player to act next.
		/// </summary>
		/// <returns></returns>
		public Player GetActivePlayer()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns the current point score. A negative number is a white lead, a positive number is a black lead
		/// </summary>
		/// <returns></returns>
		public int GetPointScore()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// This static method is called to get an initial starting position.
		/// 
		/// Step 2: should handle (as in never return) any mulligans.
		/// </summary>
		/// <returns></returns>
		public static GameState GetInitialState()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a game state as a result of an earlier game state plus a move.
		/// 
		/// Example:
		/// 
		/// var newGameState = oldGameState + playerMove;
		/// 
		/// newGameState will be the resulting game state
		/// </summary>
		/// <param name="gameState">the earlier game state</param>
		/// <param name="move">the move</param>
		/// <returns>a new game state</returns>
		public static GameState operator +(GameState gameState, Move move)
		{
			// todo: implement

			throw new NotImplementedException();
		}

		#region NavigationHelperProperties 

		[JsonIgnore]
		public Move PrecedingMove
		{
			get
			{
				var gameStates = Game.GameStates.ToList();

				var gameStateIndex = gameStates.IndexOf(this);

				if (gameStateIndex == 0)
				{
					return null;
				}

				return Game.Moves.ToList()[gameStateIndex - 1];
			}
		}

		[JsonIgnore]
		public Move SucceedingMove
		{
			get
			{
				var gameStates = Game.GameStates.ToList();

				var gameStateIndex = gameStates.IndexOf(this);

				if (Game.Moves.Count() < gameStates.Count)
				{
					return null;
				}

				return Game.Moves.ToList()[gameStateIndex];
			}
		}

		[JsonIgnore]
		public GameState PrecedingGameState
		{
			get
			{
				return PrecedingMove.PrecedingGameState;
			}
		}

		[JsonIgnore]
		public GameState SucceedingGameState
		{
			get
			{
				return SucceedingMove.SucceedingGameState;
			}
		}

		public bool IsCurrentState
		{
			get { return Game.GameStates.ToList().IndexOf(this) == Game.GameStates.Count() - 1; }
		}

		#endregion
	}
}
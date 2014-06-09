using System.Collections.Generic;
using System.Linq;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class GameState : BaseModel
	{
		public virtual Game Game { get; set; }

		#region NavigationHelperProperties 

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

		public bool IsCurrentState
		{
			get { return Game.GameStates.ToList().IndexOf(this) == Game.GameStates.Count() - 1; }
		}

		#endregion

		#region OperatorOverloads

		/// <summary>
		/// Returns a game state as a result of an earlier game state plus a move.
		/// 
		/// Example:
		/// 
		/// var newGameState = oldGameState + playerMove;
		/// </summary>
		/// <param name="gameState">the earlier game state</param>
		/// <param name="move">the move</param>
		/// <returns>a new game state</returns>
		public static GameState operator +(GameState gameState, Move move)
		{
			// todo: implement the new game state as a result of an earlier game state PLUS a move.

			return new GameState();
		}

		#endregion
	}
}
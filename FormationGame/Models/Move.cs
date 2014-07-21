using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BitFrame.Models;
using Newtonsoft.Json;

namespace FormationGame.Models
{
	public enum MoveType
	{
		Push,
		Jump,
		Split,
		Switch,
		Boost,
		Fourify,
		Match,
		Destroy
	}

	public enum MoveDirection
	{
		Up,
		Down
	}

	public class Move : BaseModel
	{
		[JsonIgnore]
		public virtual Game Game { get; set; }


		// todo: implement needed properties


		/// <summary>
		/// Returns a game state as a result of an earlier game state plus a move.
		/// 
		/// Example:
		/// 
		/// var newGameState = playerMove.ApplyToGameState(currentGameState)
		/// 
		/// newGameState will be the resulting game state.
		/// 
		/// If the current move cannot be performed, it should throw an exception.
		/// </summary>
		/// <param name="gameState">the earlier game state</param>
		/// <returns>a new game state</returns>
		public GameState ApplyToGameState(GameState gameState)
		{
			// todo: implement

			throw new NotImplementedException();
		}

		#region NavigationHelperMethods

		public GameState PrecedingGameState()
		{

			var moveIndex = Game.Moves.IndexOf(this);

			return Game.GameStates[moveIndex];
		}

		public GameState SucceedingGameState()
		{
			var moveIndex = Game.Moves.IndexOf(this);

			if (Game.GameStates.Count <= moveIndex)
			{
				return null;
			}

			return Game.GameStates[moveIndex + 1];
		}

		public bool Equals(Move move)
		{
			if (move == null)
			{
				return false;
			}

			// todo: implement the comparison

			throw new NotImplementedException();

		}

		#endregion
	}
}
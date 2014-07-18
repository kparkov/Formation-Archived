using System;
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
		/// var newGameState = oldGameState + playerMove;
		/// 
		/// newGameState will be the resulting game state.
		/// 
		/// Any resulting, illegal game state should throw an exception.
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
		public virtual GameState PrecedingGameState
		{
			get
			{
				var moveIndex = Game.Moves.IndexOf(this);

				return Game.GameStates[moveIndex];
			}
		}

		[JsonIgnore]
		public virtual GameState SucceedingGameState
		{
			get
			{
				var moveIndex = Game.Moves.IndexOf(this);

				if (Game.GameStates.Count <= moveIndex)
				{
					return null;
				}

				return Game.GameStates[moveIndex + 1];
			}
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
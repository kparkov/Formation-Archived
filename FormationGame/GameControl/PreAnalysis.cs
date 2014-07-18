using System.Collections.Generic;
using System.Collections.ObjectModel;
using FormationGame.Models;

namespace FormationGame.GameControl
{
	public class PreAnalysis
	{
		/// <summary>
		/// Takes a game state and analyzes the current options for that game state, returning the full set.
		/// </summary>
		/// <param name="gameState">The game state</param>
		/// <returns>A list of possible moves</returns>
		public List<Move> Options(GameState gameState)
		{
			var result = new List<Move>();

			// todo: make the actual analysis

			return result;
		}

		public ReadOnlyCollection<MoveType> AllMoveTypes()
		{
			return new List<MoveType>
			{
				MoveType.Boost,
				MoveType.Destroy,
				MoveType.Fourify,
				MoveType.Jump,
				MoveType.Match,
				MoveType.Push,
				MoveType.Split,
				MoveType.Switch
			}
			.AsReadOnly();
		} 
	}
}
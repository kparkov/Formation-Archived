using System;
using FormationGame.Models;

namespace FormationGame.GameControllers
{
	public class PostAnalysis
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameState"></param>
		/// <param name="move"></param>
		/// <returns>True if the move parameter represents a valid move, false otherwise</returns>
		public bool IsValidMove(GameState gameState, Move move)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameState"></param>
		/// <returns>True if game is an end game state, false otherwise</returns>
		public bool IsEndGame(GameState gameState)
		{
			throw new NotImplementedException();
		}
	}
}
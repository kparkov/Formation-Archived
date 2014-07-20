using System.Collections.Generic;
using BitFrame.Models;
using FormationGame.Models;

namespace FormationGame.GameControllers
{
	public sealed class GameFlow
	{
		/// <summary>
		/// Make sure database exists, and that base data (for example players) exists.
		/// 
		/// This method WORKS.
		/// </summary>
		public void PrepareDatabase()
		{
			var database = new GameDatabase();
			database.Initialize();
		}

		/// <summary>
		/// Return a player object by referencing the players user name.
		/// 
		/// This method WORKS.
		/// </summary>
		/// <param name="userName">The username as a string</param>
		/// <returns>A player object</returns>
		public Player GetPlayerByUserName(string userName)
		{
			return Repository.Get<Player>().Where(x => x.UserName == userName).One();
		}

		/// <summary>
		/// Starts a new game, saves it to the database, and returns it.
		/// 
		/// DOES NOT WORK.
		/// </summary>
		/// <param name="white">The white player object</param>
		/// <param name="black">The black player object</param>
		/// <returns>The new and persisted game object</returns>
		public Game StartGame(Player white, Player black)
		{
			var game = Game.GetNewGame(white.AsUnchanged(), black.AsUnchanged())
				.AsNewGraph()
				.PersistGraph();

			return game;
		}

		/// <summary>
		/// Given a game and a move, checks if the move can be applied to the game via POST-ANALYSIS.
		/// 
		/// DOES NOT WORK.
		/// </summary>
		/// <param name="game">A game object</param>
		/// <param name="move">A move object</param>
		/// <returns>A boolean indicating whether this move is legal</returns>
		public bool CheckMoveIsLegal(Game game, Move move)
		{
			var postAnalysis = new PostAnalysis();

			return postAnalysis.IsValidMove(game.CurrentState, move);
		}

		/// <summary>
		/// Given a game, checks if that game is won (has ended) via POST-ANALYSIS.
		/// 
		/// DOES NOT WORK.
		/// </summary>
		/// <param name="game">A game object</param>
		/// <returns>A boolean indicating whether the game is won</returns>
		public bool CheckGameIsWon(Game game)
		{
			var postAnalysis = new PostAnalysis();

			return postAnalysis.IsEndGame(game.CurrentState);
		}

		/// <summary>
		/// Given a game, returns the current options for the active player via PRE-ANALYSIS.
		/// 
		/// DOES NOT WORK.
		/// </summary>
		/// <param name="game">A game object</param>
		/// <returns>A collection of legal moves</returns>
		public IEnumerable<Move> GetOptionsInGame(Game game)
		{
			var preAnalysis = new PreAnalysis();

			return preAnalysis.Options(game.CurrentState);
		}

		/// <summary>
		/// Given a game and a move, applies the move and the resulting game state, and saves the game
		/// at the new state.
		/// 
		/// WILL WORK AUTOMATICALLY WHEN THE ABOVE HAS BEEN IMPLEMENTED CORRECTLY.
		/// </summary>
		/// <param name="game">A game object</param>
		/// <param name="move">A move object</param>
		/// <returns>An updated and saved game object</returns>
		public Game PerformMoveAndSave(Game game, Move move)
		{
			game.CleanStateGraph();
			game.Moves.Add(move.AsNewGraph());
			game.GameStates.Add(move.ApplyToGameState(game.CurrentState).AsNewGraph());
			game.PersistGraph();

			return game;
		}


	}
}
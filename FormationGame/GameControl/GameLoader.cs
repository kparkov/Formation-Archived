using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitFrame.Models;
using FormationGame.Models;

namespace FormationGame.GameControl
{
	public class GameLoader
	{
		public Game StartNewGame(Player whitePlayer, Player blackPlayer)
		{
			var game = new Game()
			{
				White = whitePlayer,
				Black = blackPlayer
			};

			game.GameStates.Add(GetNewStartingGameState());

			var repository = new Repository<Game>();

			repository.InsertOrUpdateGraph(game);

			return game;
		}

		public void SaveGame(Game game)
		{
			var repository = new Repository<Game>();

			game.State = State.Modified;

			game.White.State = State.Modified;
			game.Black.State = State.Modified;

			foreach (var gameState in game.GameStates)
			{
				gameState.State = State.Modified;
			}

			foreach (var move in game.Moves)
			{
				move.State = State.Modified;
			}
		}

		private GameState GetNewStartingGameState()
		{
			// todo: initialize the game state to represent a valid starting point for a game.

			return new GameState();
		}
	}
}
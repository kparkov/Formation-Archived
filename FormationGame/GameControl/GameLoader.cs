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
			var game = Game.GetNewGame(whitePlayer.AsUnchanged(), blackPlayer.AsUnchanged());

			game.AsNewGraph().PersistGraph();

			return game;
		}

		public void SaveGame(Game game)
		{
			game.AsModifiedGraph().PersistGraph();
		}

		public Player GetPlayerByUserName(string userName)
		{
			var players = new Repository<Player>();

			return Repository.Get<Player>().Where(x => x.UserName == userName).One();
		}

		public void Initialize()
		{
			SetupTestData();
		}

		private void SetupTestData()
		{
			var players = Repository.Get<Player>();

			if (players.Count() > 0) return;

			var newPlayers = new List<Player>()
			{
				new Player()
				{
					UserName = "ida",
					Email = "ida@rausch.dk",
					Password = "hest"
				}.AsNew(),
				new Player()
				{
					UserName = "kparkov",
					Email = "kparkov@gmail.com",
					Password = "hest"
				}.AsNew(),
				new Player()
				{
					UserName = "rasch",
					Email = "raschristian@gmail.com",
					Password = "hest"
				}.AsNew(),
				new Player()
				{
					UserName = "esben",
					Email = "esbenheick@gmail.com",
					Password = "hest"
				}.AsNew()
			};

			players.SaveGraph(newPlayers);
		}

	}
}
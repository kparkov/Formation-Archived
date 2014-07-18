using System.Collections.Generic;
using BitFrame.Models;
using FormationGame.Models;

namespace FormationGame.GameControllers
{
	public class GameDatabase
	{
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
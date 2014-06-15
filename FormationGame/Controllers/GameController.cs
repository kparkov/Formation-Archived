using System.Web.Mvc;
using FormationGame.GameControl;
using FormationGame.Models;

namespace FormationGame.Controllers
{
    public class GameController : FormationBaseController
    {
        public ActionResult ShowGame()
        {
	        var gameLoader = new GameLoader();

	        var white = new Player();
	        var black = new Player();

	        var game = gameLoader.StartNewGame(white, black);
			game.GameStates.Add(new GameState() { Game = game });

	        return Show(game);
        }

    }
}

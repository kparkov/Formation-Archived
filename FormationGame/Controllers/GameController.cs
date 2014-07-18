using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BitFrame.Models;
using FormationGame.GameControl;
using FormationGame.Models;

namespace FormationGame.Controllers
{
    public class GameController : FormationBaseController
    {
        public ActionResult ShowGame()
        {
	        var gameLoader = new GameLoader();

			gameLoader.Initialize();

	        var white = gameLoader.GetPlayerByUserName("esben");
	        var black = gameLoader.GetPlayerByUserName("rasch");

	        var game = gameLoader.StartNewGame(white, black);

	        return Show(game);
        }

	    public ActionResult ShowPlayer()
	    {
		    var player = new Player();

		    return Show(player);
	    }
    }
}

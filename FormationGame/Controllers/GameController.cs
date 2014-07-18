using System.Web.Mvc;
using FormationGame.GameControllers;
using FormationGame.Models;

namespace FormationGame.Controllers
{
    public class GameController : FormationBaseController
    {
        public ActionResult ShowGame()
        {
	        var flow = new GameFlow();

	        var white = flow.GetPlayerByUserName("esben");
	        var black = flow.GetPlayerByUserName("ida");

	        var game = flow.StartGame(white, black);

	        return Show(game);
        }

	    public ActionResult ShowPlayer()
	    {
		    var player = new Player();

		    return Show(player);
	    }
    }
}

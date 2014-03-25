using System.Linq;
using System.Web.Mvc;
using FormationGame.Tools;
using FormationGame.Tools.Text;

namespace FormationGame.Controllers
{
    public class ParkovController : FormationBaseController
    {
        //
        // GET: /Parkov/

        public ActionResult Index()
        {
            var player1cup = new DiceCup("Black");
            var player2cup = new DiceCup("White");

			AddToView(player1cup);
			AddToView(player2cup);

	        return ShowAddedObjects();
        }

    }
}

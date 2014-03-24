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

            return ObjectToHtml(new { p1 = player1cup, p2 = player2cup, sum1 = player1cup.SumOfDice(), sum2 = player2cup.SumOfDice(), lowest = player1cup.LowestValue() });
        }

    }
}

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
	        var die = new Die();

	        return ObjectToHtml(die);
        }

    }
}

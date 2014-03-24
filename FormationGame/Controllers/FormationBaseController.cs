using System.Web.Mvc;
using FormationGame.Tools.Text;

namespace FormationGame.Controllers
{
    public class FormationBaseController : Controller
    {
        protected TextRepresentation Texter = new TextRepresentation();

	    protected ActionResult ObjectToHtml(object Model)
	    {
		    return Content(Texter.DisplayObject(Model).ToHtmlString());
	    }
    }
}

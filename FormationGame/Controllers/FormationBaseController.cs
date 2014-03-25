using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
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

	    protected ActionResult DView(object dynamicObject)
	    {
			IDictionary<string, object> anonymousDictionary = new RouteValueDictionary(dynamicObject);
			IDictionary<string, object> expando = new ExpandoObject();
			foreach (var item in anonymousDictionary) expando.Add(item);

		    return View(expando);
	    }
    }
}

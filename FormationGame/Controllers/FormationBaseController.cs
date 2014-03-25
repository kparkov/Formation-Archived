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

		protected List<object> ViewCache = new List<object>(); 

	    protected ActionResult ObjectToHtml(object Model)
	    {
		    return Content(Texter.DisplayObject(Model).ToHtmlString());
	    }

	    protected void AddToView(object AnyObject)
	    {
		    ViewCache.Add(AnyObject);
	    }

	    protected ActionResult ShowAddedObjects()
	    {
		    return ObjectToHtml(ViewCache);
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

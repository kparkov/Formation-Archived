using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;
using FormationGame.Tools.Text;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace FormationGame.Controllers
{
    public class FormationBaseController : Controller
    {
        protected TextRepresentation Texter = new TextRepresentation();

		protected List<object> ViewCache = new List<object>(); 

	    protected ActionResult ObjectToHtml(object model)
	    {
		    return Content(Texter.DisplayObject(model).ToHtmlString());
	    }

	    protected void AddToView(params object[] objects)
	    {
		    objects.ToList().ForEach(x => ViewCache.Add(x));
	    }

		protected ActionResult ShowObjects(params object[] objectsToAdd)
	    {
		    AddToView(objectsToAdd);

			return ObjectToHtml(ViewCache);
	    }

	    protected ActionResult DView(object dynamicObject)
	    {
			IDictionary<string, object> anonymousDictionary = new RouteValueDictionary(dynamicObject);
			IDictionary<string, object> expando = new ExpandoObject();
			foreach (var item in anonymousDictionary) expando.Add(item);

		    return View(expando);
	    }

	    public ActionResult Show(object o)
	    {
		    var type = o.GetType().ToString();

		    var json = JsonConvert.SerializeObject(o);

		    var result = type + json
				.Replace("{", "<div style=\"margin-left:1em\"><strong>{</strong><div style=\"margin-left:1em\">")
			    .Replace("}", "</div><strong>}</strong></div>")
			    .Replace(",", "<br/>");

			result = String.Format("{0}{1}{2}", "<div style=\"font-family:sans-serif;font-size:14px;line-height:1.5em;\">", result, "</div>");

		    return Content(result);
	    }
    }
}

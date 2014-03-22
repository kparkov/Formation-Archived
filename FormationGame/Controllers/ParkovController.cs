using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using FormationGame.Tools;
using FormationGame.Tools.Text;
using FormationGame.ViewModels;

namespace FormationGame.Controllers
{
    public class ParkovController : Controller
    {
        //
        // GET: /Parkov/

        public ActionResult Index()
        {
	        var tf = new TextFormatter();

	        var dicePool = Enumerable.Range(1, 5).Select(x => new Die());

	        return Content(tf.DisplayObject(dicePool).ToHtmlString());
        }

    }
}

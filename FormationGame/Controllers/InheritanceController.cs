using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormationGame.Training;

namespace FormationGame.Controllers
{
    public class InheritanceController : Controller
    {
        //
        // GET: /Inheritance/

        public ActionResult Index()
        {
	        return new InheritanceDemo().Demo();
        }

    }
}

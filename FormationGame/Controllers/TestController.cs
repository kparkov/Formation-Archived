using FormationGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            TestViewModel ViewModel = new TestViewModel();

            ViewModel.MessageForTheUser = "Denne besked bliver dannet i C#, og vises så her i HTML-dokumentet.";

            return View(ViewModel);
        }

    }
}

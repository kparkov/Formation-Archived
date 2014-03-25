using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FormationGame.Tools;
using FormationGame.Tools.Text;
using FormationGame.ViewModels;

namespace FormationGame.Controllers
{

	// Parkovs klasser
    public class DarklordController : FormationBaseController
    {
        public ActionResult Index()
        {
	        return ShowObjects();
        }

    }

	public class Darklord
	{
		public string MyString { get; set; }				// "A dark and hungry God arises", ""
		public int MyInt { get; set; }						// 3, 8, 1024, -6
		public bool MyBoolean { get; set; }					// true, false
		public decimal MyDecimal { get; set; }				// 3.141592m, 0.5m, 2.25m, 1.2m
		public DateTime MyDateTime { get; set; }			// new DateTime(2014, 3, 26)
	}
}

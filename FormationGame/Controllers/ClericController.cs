using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
	//Idas klasser
    public class ClericController : FormationBaseController
    {
        public ActionResult IdaView()
        {
            return View();
        }

		// KODE TIL LEKTION 3
	    public ActionResult Index()
	    {
			// Her begynder vi ved tredje lektion:
            var supercleric = new Cleric
            {
                Name = "Yrsa",
                Faith = 22,
                Wisdom = 18,
                Presence = 20,
                IsGood = false,
                Prügelknabe = new ClericFollower 
                { 
                Name = "Syndige Sigurd",
                Race = "Gnome"
                }
            };
            return ShowObjects(supercleric);

			// Denne metode kan benyttes til at vise indholdet af variabler
		    /*Slet denne kommentar og erstat med variabler*/
	    }
    }

	// MODEL:
	public class Cleric
	{
        public string Name { get; set; }
        public int Faith { get; set; }
        public int Wisdom { get; set; }
        public int Presence { get; set; }
        public bool IsGood { get; set; }
        public ClericFollower Prügelknabe { get; set; }
	}
    public class ClericFollower
    {
        public string Race { get; set; }
        public string Name { get; set; }
    }
}

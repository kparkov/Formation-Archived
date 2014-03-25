using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
	//Esbens klasser
    public class FighterController : FormationBaseController
    {
        public ActionResult MyNewAction()
		{

            var Dieposition1 = new Tools.Die();
            var Dieposition2 = new Tools.Die();

            AddToView(Dieposition1);
            AddToView(Dieposition2);
            
            return ShowObjects(); 
        
        }

		// KODE TIL LEKTION 3
		public ActionResult Index()
		{
			// Her begynder vi ved tredje lektion:


			// Denne metode kan benyttes til at vise indholdet af variabler
			return ShowObjects(/*Slet denne kommentar og erstat med variabler*/);
		}

    }

	// MODEL:
	public class Fighter
	{
	}
}

using FormationGame.Tools;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FormationGame.Controllers
{

	// Parkovs klasser
    public class DarklordController : FormationBaseController
    {

        public ActionResult Index()
        {
	        var myLittleDarklord = GetNewRandomDarklord();

			// Her viser vi modellen på skærmen. Kør koden ved at trykke play og gå ind på: /Darklord
	        return ShowObjects(myLittleDarklord);
        }

	    protected Darklord GetNewRandomDarklord()
	    {
			var randomNames = new NameList();

			var darklord = new Darklord
			{
				Name = randomNames.GetRandomFullNameMethod1(),
				Evilness = new DiceCup("Black").SumOfDice(),
				Power = new DiceCup("As black as a moonless night").SumOfDice(),
				Insanity = new DiceCup("Black no. 1").SumOfDice(),
				NoOfMinions = new DiceCup("Paint it black").SumOfDice()
			};

		    return darklord;
	    }

    }

	// MODEL:
	public class Darklord
	{
		public string Name { get; set; }
		public int Evilness { get; set; }
		public int Power { get; set; }
		public int Insanity { get; set; }
		public int NoOfMinions { get; set; }
	}
}

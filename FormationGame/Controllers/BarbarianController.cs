using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
	// Jonas' klasser
    public class BarbarianController : FormationBaseController
    {
		// KODE TIL LEKTION 3
		public ActionResult Index()
		{
            var Burak = new Barbarian
            {
                Name = "Burak",
                Title = "Burak The Destroyer",
                Strength = "MAX",
                Awesomeness = 99,
                Handsomeness = -4,
                Goodness = 3,
                Height = 2.20m,
                SpecialAbilities = "Drunken Madness & Power Slam Of Decay",
                Pet = new companion

                {
                    Name = "Didrik",
                    Race = "Bear",
                    Title = "Didrik The Über Awesome Bear",
                    Awesomeness = 46,
                    SpecialAbilities = "Trout Fishing Madness & Roar Of Doom And Deststruction"
                }
            };


			// Denne metode kan benyttes til at vise indholdet af variabler
			return ShowObjects(Burak);
		}
    }

	// MODEL:
	public class Barbarian
	{
        public string Name { get; set; }
        public string Title { get; set; }
        public string Strength { get; set; }
        public decimal Height { get; set; }
        public int Handsomeness { get; set; }
        public int Goodness { get; set; }
        public int Awesomeness { get; set; }
        public string SpecialAbilities { get; set; }

        public companion Pet { get; set; }
	}
    public class companion
        {
        public string Race { get; set; }
        public string Name { get; set; }
        public int Awesomeness { get; set; }
        public string Title { get; set; }
        public string SpecialAbilities { get; set; }
    }

}
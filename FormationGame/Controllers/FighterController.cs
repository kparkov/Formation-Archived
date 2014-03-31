using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
    public class FighterController : FormationBaseController
    {
        public ActionResult ReturnFighter()
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
            var swordsman = new Fighter
            {
                name = "Fredrik",
                race = "menneske",
                specialties = new List<weapontype>
                {
                    new weapontype {
                        weaponclass = "swords"
                    },
                    new weapontype {
                        weaponclass = "axes"
                    }
                },
                minimumStrenghtRequired = 10,
                maximumIntelligenceAllowed = 2,
                shoulderwidth = 100,
                IsAngry = true

            };
            

			// Denne metode kan benyttes til at vise indholdet af variabler
			return ShowObjects(swordsman);
		}

    }

	// MODEL:
	public class Fighter
	{
        public string name { get; set; }
        public string race { get; set; }
        public List <weapontype> specialties { get; set; }
        public int minimumStrenghtRequired { get; set; }
        public int maximumIntelligenceAllowed { get; set; }
        public int shoulderwidth { get; set; }
        public bool IsAngry {get; set;}
        public string Title
		{
			get { return name + " The Master of " + String.Join(" and ", specialties.Select(x => x.weaponclass)); }
        }
	}

    public class weapontype
    {
        public string weaponclass { get; set; }
    }
 
}

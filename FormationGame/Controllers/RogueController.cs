using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
	// Karis klasser
	public class RogueController : FormationBaseController
	{

        public ActionResult RogueView()
        {
                        return ShowObjects();
        }
            

		// KODE TIL LEKTION 3
		public ActionResult Index()
		{
			// Her begynder vi ved tredje lektion:
            var sneakRogue = new Rogue
            {
                Name = "Venomous Vera",
                stealth = 7,
                poisonStrength = 6,
                charm = 2,
                weapon = new RogueAttack
                {
                    Type = "dagger",
                    IsPoisenous = true,
                    SpecialAbilities = new List<string>
                    {
                        "one-handed",
                        "dagger of death"
                    }
                }
            };

			// Denne metode kan benyttes til at vise indholdet af variabler
			return ShowObjects(sneakRogue);
		}


        // Modulus test
        public ActionResult modulus()
        {
            int a = 2;
            int b = 13;

            // 13 modulus 2
            int result = b % a; 
            return ShowObjects(result);

            
        }
	}

	// MODEL:
	public class Rogue
	{
        public string Name { get; set; }
        public int stealth { get; set; }
        public int poisonStrength { get; set; }
        public int charm { get; set; }

        public RogueAttack weapon { get; set; }

	}
    public class RogueAttack 
    {
        public string Type { get; set; }
        public bool IsPoisenous { get; set; }
        public List<string> SpecialAbilities { get; set; }
    }
}


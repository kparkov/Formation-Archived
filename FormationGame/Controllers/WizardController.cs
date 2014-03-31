using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
	// Raschs klasser
    public class WizardController : FormationBaseController
    {
		// KODE TIL LEKTION 3
		public ActionResult Index()
		{
			// Her begynder vi ved tredje lektion
            int defaultHitPoints = 40;
            var thisWeeksFamousWizard = new Wizard
            {
                name = "Silly Wizard of Nørrebro",
                hitPoints = defaultHitPoints,
                currentHitPoints = defaultHitPoints,
                armor = 5,
                mana = 40,
                imuneToFireSpells = false,
                imuneToColdSpells = false,
                spells = new List<WizardSpell> 
                {
                    new WizardSpell()
                    {
                        name = "Minor fireball",
                        fireDamage = 4,
                        isRanged = true
                    },
                    new WizardSpell()
                    {
                        name = "Minor snowball",
                        coldDamage = 2,
                        isRanged = true
                    },
                    new WizardSpell()
                    {
                        name = "Minor healing",
                        healingEffect = 1,
                        isRanged = false
                    }
                }

            };


			// Denne metode kan benyttes til at vise indholdet af variabler
			return ShowObjects(thisWeeksFamousWizard);
		}
    }

	// MODEL: 
	public class Wizard
	{
        public string name { get; set; }
        public int hitPoints { get; set; }
        public int currentHitPoints { get; set; }
        public int armor { get; set; }
        public int mana { get; set; }
        public bool imuneToColdSpells { get; set; }
        public bool imuneToFireSpells { get; set; }
        public List<WizardSpell> spells { get; set; }
	}

    public class WizardSpell
    {
        public string name { get; set; }
        public int fireDamage { get; set; }
        public int coldDamage { get; set; }
        public int healingEffect { get; set; }
        public bool isRanged { get; set; }
    }
}

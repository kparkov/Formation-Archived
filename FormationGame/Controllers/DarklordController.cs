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
	        var minorDarklord = new Darklord
	        {
				Name = "Bjarne The Defiler",
				Evilness = 4,
				IsSupernatural = false,
				Height = 1.68m,
				Created = new DateTime(2013, 3, 26),
				Pet = new DarklordFamiliar
				{
					Race = "Pinguin",
					Name = "Futte",
					SpecialAbilities = new List<string>
					{
						"infamous fish-eating",
						"squeak of terror"
					}
				}
	        };

			// Her viser vi modellen på skærmen. Kør koden ved at trykke play og gå ind på: /Darklord
	        return ShowObjects(minorDarklord);
        }

    }

	// MODEL:
	public class Darklord
	{
		public string Name { get; set; }					// "Lord of Banjohjælm", "Bertram the unholy"
		public int Evilness { get; set; }					// 3, 8, 1024, -6
		public bool IsSupernatural { get; set; }			// true, false
		public decimal Height { get; set; }					// 3.141592m, 0.5m, 2.25m, 1.2m
		public DateTime Created { get; set; }				// new DateTime(2014, 3, 26)

		public DarklordFamiliar Pet { get; set; }			// new DarklordFamiliar() { ... }
	}

	// ENDNU EN MODEL:
	public class DarklordFamiliar
	{
		public string Race { get; set; }
		public string Name { get; set; }

		public string Title
		{
			get { return Name + " The " + Race + ", Master of " + SpecialAbilities[0]; }
		}

		public List<string> SpecialAbilities { get; set; }
	}
}

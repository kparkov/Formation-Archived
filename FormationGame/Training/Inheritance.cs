using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormationGame.Tools;

namespace FormationGame.Training
{
	public class Character
	{
		public string Name { get; set; }

		public int Level { get; set; }
		public int ExperiencePoints { get; set; }

		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Constitution { get; set; }
		public int Intelligence { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }

		public int CombatScore()
		{
			return Strength + Dexterity + Constitution;
		}
	}


	public class InheritanceDemo
	{
		public ActionResult Demo()
		{
			var myCharacter = new Character()
			{
				Name = "Shaarlan",
				Level = 4,
				ExperiencePoints = 7600,
				Strength = 8,
				Dexterity = 15,
				Constitution = 10,
				Intelligence = 17,
				Wisdom = 13,
				Charisma = 16
			};

			var text = GetHeadline(myCharacter) + " - Combat score: " + myCharacter.CombatScore();

			return new ContentResult() {Content = text};
		}

		protected string GetHeadline(Character character)
		{
			return character.Name + " (level " + character.Level + ")";
		}
	}
}
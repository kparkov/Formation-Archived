using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

			var text = GetHeadline(myCharacter) + ", average: " + AverageAttributeScore(myCharacter);

			return new ContentResult() {Content = text};
		}
		
		protected decimal AverageAttributeScore(Character character)
		{
			return (character.Strength + character.Dexterity + character.Constitution + character.Intelligence + character.Wisdom + character.Charisma) / 6m;
		}

		protected string GetHeadline(Character character)
		{
			return character.Name + " (level " + character.Level + ")";
		}
	}
}
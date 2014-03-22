using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationGame.Tools
{
	public class Die
	{
		public int Value { get; set; }

		private static Random Randomizer = new Random();

		public Die()
		{
			Roll();
		}

		public void Roll()
		{
			Value = Randomizer.Next(1, 6);
		}
	}
}
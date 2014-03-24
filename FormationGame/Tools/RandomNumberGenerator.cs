using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationGame.Tools
{
	public class RandomNumberGenerator
	{
		private static Random Randomizer = new Random();

		public int GetRandomNumber(int MinimumValue, int MaximumValue)
		{
			return Randomizer.Next(MinimumValue, MaximumValue + 1);
		}
	}
}
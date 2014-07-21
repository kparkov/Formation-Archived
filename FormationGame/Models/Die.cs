using System;
using BitFrame.Models;
using FormationGame.Tools;

namespace FormationGame.Models
{
	public enum DieColor
	{
		White,
		Black
	}

    public class Cell : BaseModel { }


    public class EmptyCell : Cell {  }

	public class Die : Cell
	{
		private RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

		public int Value { get; set; }
		public DieColor Color { get; set; }

		/// <summary>
		/// Roll the die and update the value
		/// </summary>
		public void Roll()
		{
            Value = randomNumberGenerator.GetRandomNumber(1, 6);
		}
	}
}
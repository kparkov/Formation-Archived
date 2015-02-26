using System;

namespace Formation.Data.Model
{
    public class Die : GameBoardCell
    {
        private static Random randomizer = new Random();

        public int Value { get; set; }

        public Die()
        {
            Roll();
        }

        public void Roll()
        {
           Value = randomizer.Next(1, 7);
        }
    }
}
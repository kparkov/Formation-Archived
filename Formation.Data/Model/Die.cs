using System;

namespace Formation.Data.Model
{
    public class Die : GameBoardCell
    {
        private static Random randomizer = new Random();

        public int Value { get; set; }

        public Die()
        {
        }

        public void Roll()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationGame.Tools
{
    public class DiceCup
    {
        public List<Die> Dice { get; set; }

        public DiceCup(string color)
        {
            Dice = new List<Die>();

            for (int i = 0; i < 5; i++)
            {
                Dice.Add(new Die() { 
                    Color = color
                });
            }
        }

        public int SumOfDice()
        {
            int sum = 0;

            foreach (var die in Dice)
            {
                sum = sum + die.Value;
            }

            return sum;
        }

        public int LowestValue()
        {
            int lowestFoundSoFar = 7;

            foreach (var die in Dice)
            {
                if (die.Value < lowestFoundSoFar) 
                {
                    lowestFoundSoFar = die.Value;
                }
            }

            return lowestFoundSoFar;
        }

        public int NumberOf6Values()
        {
            int count = 0;

            foreach (var die in Dice)
            {
                if (die.Value == 6)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
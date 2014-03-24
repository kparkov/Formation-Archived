using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationGame.Tools
{
    public class DiceCup
    {
        public List<Die> Dice { get; set; }

        // Constructor - køres én gang, når en terning laves
        public DiceCup(string color)
        {
            // Fordi List er et objekt, skal vi huske at lave et nyt objekt til at starte med.
            Dice = new List<Die>();

            // Vi vil gerne lave præcis 5 terninger.
            // for (erklæring af tæller; betingelse til fortsat kørsel; inkrementering)
            // int i = 0;   -> vi starter med 0
            // i < 5;       -> fortsæt, så længe i er mindre end 5
            // i++          -> læg 1 til hver gang (forkortelse af i = i + 1)
            for (int i = 0; i < 5; i++)
            {

                // Tilføj en ny Die til listen Dice
                Dice.Add(new Die() { 
                    Color = color
                });
            }
        }

        // Finder summen af terninger
        public int SumOfDice()
        {

            // Vi starter med en sum på 0
            int sum = 0;

            // For hver terning i listen...
            foreach (var die in Dice)
            {
                // Summen skal nu være summen plus den nuværende ternings værdi.
                sum = sum + die.Value;
            }

            // Returnér summen
            return sum;
        }

        // Finder puljens laveste værdi
        public int LowestValue()
        {
            // Vi starter med at sætte den laveste værdi til et umuligt højt tal
            int lowestFoundSoFar = 7;

            // For hver terning i listen...
            foreach (var die in Dice)
            {

                // Hvis den nuværende ternings værdi er mindre end den nuværende, laveste værdi...
                if (die.Value < lowestFoundSoFar) 
                {

                    // ... så sæt den laveste værdi til den nuværende.
                    lowestFoundSoFar = die.Value;
                }
            }

            // Returnér variablen
            return lowestFoundSoFar;
        }

        // Find antallet af 6'ere.
        public int NumberOf6Values()
        {
            // Sæt antallet til 0
            int count = 0;

            // For hver terning i puljen...
            foreach (var die in Dice)
            {
                // ... hvis den nuværende terning har værdien 6...
                if (die.Value == 6)
                {
                    // ... så læg 1 til antallet.
                    count++;
                }
            }

            // Returnér antallet.
            return count;
        }
    }
}
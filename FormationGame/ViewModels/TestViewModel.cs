using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationGame.ViewModels
{
    public class TestViewModel
    {
        // Properties
        public string MessageForTheUser { get; set; }

        // Methods
        public string GetACountFromTo(int from, int to)
        {
            var ListOfNumbers = new List<int>();

            for (int i = from; i <= to; i++)
            {
                ListOfNumbers.Add(i);
            }

            return String.Join(", ", ListOfNumbers);
        }
    }
}
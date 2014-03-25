using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormationGame.Tools;

namespace FormationGame.Controllers
{
    public class CodeExamplesController : FormationBaseController
    {
        //
        // GET: /CodeExample/

        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult IfBasicExamples()
	    {
		    var whiteDie = new Die()
		    {
			    Color = "White"
		    };

		    var blackDie = new Die()
		    {
			    Color = "Black"
		    };

		    string winner = "";

			// Større end og mindre end: > og <
		    if (whiteDie.Value > blackDie.Value)
		    {
			    winner = "Hvid";
		    } else if (whiteDie.Value < blackDie.Value)
		    {
			    winner = "Sort";
		    }
		    else if (blackDie.Value == whiteDie.Value) // Når vi spørger til om de er ens, bruger vi dobbelt lig med
		    {
			    winner = "Uafgjort";
		    }

		    string equality = "";

			// Operatoren != betyder "ikke lig med"
		    if (whiteDie.Value != blackDie.Value)
		    {
			    equality = "De to værdier er forskellige";
		    }
		    else
		    {
			    equality = "De to værdier er ens";
		    }

		    return DView(new
		    {
			    White = whiteDie,
				Black = blackDie,
				Winner = winner,
				Equality = equality
		    });

	    }

	    public ActionResult ForBasicExamples()
	    {
		    int startCount = 0;
		    int endCount = 10;
		    int step = 1;

			var excludingEndCount = new List<int>();

			// This loop will NOT include the endCount
		    for (int counter = startCount; counter < endCount; counter = counter + step)
		    {
			   excludingEndCount.Add(counter); 
		    }

		    var includingEndCount = new List<int>();

			// This loop will include the end count
		    for (int counter = startCount; counter <= endCount; counter = counter + step)
		    {
			    includingEndCount.Add(counter);
		    }

		    startCount = 10;
		    endCount = 40;
		    step = 7;

		    var oddSteps = new List<int>();

			// This loop makes small steps for a loop, but giant steps for loopkind
		    for (int counter = startCount; counter < endCount; counter = counter + step)
		    {
			    oddSteps.Add(counter);
		    }

		    startCount = 10;
		    endCount = 0;
		    step = -1;

		    var countDown = new List<int>();

			// This loop counts backwards
		    for (int counter = startCount; counter >= endCount; counter = counter + step)
		    {
			    countDown.Add(counter);
		    }

		    return DView(new
		    {
			    ExcludingEndCount = excludingEndCount,
				IncludingEndCount = includingEndCount,
				OddSteps = oddSteps,
				CountDown = countDown
		    });
	    }

	    public ActionResult ForeachBasicExamples()
	    {
		    List<string> listOfNames = new List<string>();

			listOfNames.Add("Parkov");
			listOfNames.Add("Ida");
			listOfNames.Add("Esben");
			listOfNames.Add("Rasch");
			listOfNames.Add("Kari");
			listOfNames.Add("Jonas");
			listOfNames.Add("Luca");

		    string singleLineWithNames = "";

			// foreach 
		    foreach (var name in listOfNames)
		    {
			    singleLineWithNames = singleLineWithNames + name + ", ";
		    }

			// Husk at alle lister er baseret på et 0-indeks - det første navn har position 0.
		    string nameOn4thPosition = listOfNames[4];

		    string singleLineWithStandardFor = "";

			// for loop med samme effekt som foreach - vi bruger tælleren til at vælge navnet
		    for (int i = 0; i < listOfNames.Count; i++)
		    {
			    singleLineWithStandardFor = singleLineWithStandardFor + listOfNames[i] + ", ";
		    }

		    return DView(new
		    {
			    ListOfNames = listOfNames,
				SingleLineWithNames = singleLineWithNames,
				NameOn4thPosition = nameOn4thPosition,
				SingleLineWithStandardFor = singleLineWithStandardFor
		    });
	    }

    }
}

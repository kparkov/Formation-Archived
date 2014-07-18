using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YamlDotNet.Core;

namespace FormationGame.Controllers
{
	public class Person
	{
		public string Name { get; set; }
		public int BirthYear { get; set; }
		public int Money { get; set; }
	}


    public class LinqExamplesController : FormationBaseController
    {
        private List<Person> people = new List<Person>()
        {
	        new Person()
	        {
		        Name = "Ole",
				BirthYear = 1965,
				Money = 12000
	        },
			new Person()
			{
				Name = "Bitten",
				BirthYear = 1957,
				Money = 14500
			},
			new Person()
			{
				Name = "Hans-Christian",
				BirthYear = 1899,
				Money = 250
			},
			new Person()
			{
				Name = "Tobias",
				BirthYear = 1984,
				Money = 7000
			}
        }; 

        public ActionResult AllPeople()
        {
            return Show(people);
        }

	    public ActionResult FilterPeopleUnderFifty1()
	    {
		    var peopleUnderFifty = new List<Person>();

		    var earliestBirthYear = DateTime.Now.Year - 50;

		    foreach (var person in people)
		    {
			    if (person.BirthYear >= earliestBirthYear)
			    {
				    peopleUnderFifty.Add(person);
			    }
		    }

		    return Show(peopleUnderFifty);
	    }

	    public ActionResult FilterPeopleUnderFifty2()
	    {
		    var peopleUnderFifty = people.Where(person => person.BirthYear >= (DateTime.Now.Year - 50));

		    return Show(peopleUnderFifty);
	    }

	    public ActionResult SumMoney()
	    {
		    var moneyCombined = people.Sum(person => person.Money);

		    return Show(moneyCombined);
	    }

	    public ActionResult OtherLinqFunctions()
	    {
		    IEnumerable<Person> result;

		    // Take and skip
		    result = people.Skip(2).Take(1);




		    return Show(result);

	    }

    }
}

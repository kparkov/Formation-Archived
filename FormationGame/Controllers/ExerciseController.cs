using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
    public class ExerciseController : FormationBaseController
    {
		public ActionResult Index()
		{
			var itemsInShoppingCart = new List<GroceryItem>
			{
		        new GroceryItem
		        {
			        Product = "Kartofler",
			        Price = 10
		        },
		        new GroceryItem
		        {
			        Product = "Mælk",
			        Price = 8
		        },
		        new GroceryItem
		        {
			        Product = "Mel",
			        Price = 17
		        },
		        new GroceryItem
		        {
			        Product = "Smør",
			        Price = 14
		        }
	        };

			var orderedList = new List<string> {"One", "Two", "Three"};

			var colors = new List<string> {"Green", "Yellow", "Red"};
			var fruits = new List<string> {"Kiwi", "Banana", "Apple"};

			return ShowObjects(new
			{
				SumOfTwo = SumOfNumbers(12, 15),
				ProductOfTwo = ProductOfNumbers(12, 15),
				XHigherThanY = IsXHigherThanY(20, 13),
				GoodGuysWins = DoTheGoodGuysWin(12, 9, 14, 7),
				StringOfCharacters = GetStringOfCharacters('Q', 17),
				SpacesBeforeStringOfCharacters = GetStringOfCharactersWithSpacesBefore('W', 12, 8),
				Christmas = GetChristmasTree(),
				CitizenType = GetCitizenType(48),
				ReversedOrderList = ReverseOrderOfList(orderedList),
				ColoredFruits = GetColoredFruits(colors, fruits),
				GroceriesTotalPrice = GetPriceForGroceries(itemsInShoppingCart),
				HasEnoughMoney = HasEnoughMoneyToBuyStuff(47, itemsInShoppingCart),
				PrettySummary = SummaryLine(itemsInShoppingCart),
				DanishWeekdayExample = DanishWeekday(new DateTime(1980, 8, 9)),
				RoundBirthDayWeekdaysExample = WeekdaysOfMyRoundBirthdays(new DateTime(1980, 8, 9)),
			});
		}


		/// <summary>
		/// OPGAVE 1:
		/// 
		/// Summerer to tal
		/// </summary>
		/// <param name="x">Første tal</param>
		/// <param name="y">Andet tal</param>
		/// <returns>Summen</returns>
	    public int SumOfNumbers(int x, int y)
		{
			return 0;
		}

		/// <summary>
		/// OPGAVE 2:
		/// 
		/// Produktet af to tal
		/// </summary>
		/// <param name="x">Første tal</param>
		/// <param name="y">Andet tal</param>
		/// <returns>Produktet</returns>
	    public int ProductOfNumbers(int x, int y)
	    {
		    return 0;
	    }

		/// <summary>
		/// OPGAVE 3:
		/// 
		/// Givet to tal, ønskes en vurdering af, om X er højere end Y
		/// </summary>
		/// <param name="x">Første tal</param>
		/// <param name="y">Andet tal</param>
		/// <returns>Om X er højere end Y</returns>
	    public bool IsXHigherThanY(int x, int y)
	    {
		    return false;
	    }

		/// <summary>
		/// OPGAVE 4:
		/// 
		/// Givet antal good guys og deres individuelle styrke, samt bad guys og deres individuelle styrke,
		/// ønskes en vurdering af, om de gode mon vinder denne runde.
		/// </summary>
		/// <param name="numberOfGoodGuys">Antal good guys</param>
		/// <param name="strengthOfEachGoodGuy">Hvor stærk hver good guy er</param>
		/// <param name="numberOfBadGuys">Antal bad guys</param>
		/// <param name="strengthOfEachBadGuy">Hvor stærk hver bad guy er</param>
		/// <returns>Om de gode vinder</returns>
	    public bool DoTheGoodGuysWin(int numberOfGoodGuys, int strengthOfEachGoodGuy, int numberOfBadGuys, int strengthOfEachBadGuy)
		{
			return false;
		}

	    /// <summary>
	    /// OPGAVE 5:
	    /// 
	    /// Tager et tal og et tegn, og returnerer en tekst der gentager tegnet et tilsvarende antal gange.
	    /// 
	    /// Eksempel: GetStringOfCharacters('F', 4) => "FFFF"
	    /// </summary>
	    /// <param name="characterToRepeat">Tegnet der ønskes gentaget</param>
	    /// <param name="numberOfTimes">Antal gange det skal gentages</param>
	    /// <returns>En tekst bestående af et gentaget tegn</returns>
	    public string GetStringOfCharacters(char characterToRepeat, int numberOfTimes)
		{
			return "";
		}

	    /// <summary>
	    /// OPGAVE 6:
	    /// 
	    /// Samme som ovenfor, men vi ønsker nu at kunne angive antal mellemrum der skal komme før tegnet.
	    /// 
	    /// Eksempel: GetStringOfStarsWithSpacesAround('K', 3, 2) => "   KK"
	    /// 
	    /// HINT: DON'T REPEAT YOURSELF
	    /// </summary>
	    /// <param name="characterToRepeat">Tegn der ønskes gentaget</param>
	    /// <param name="spacesBefore">Mellemrum der ønskes før</param>
	    /// <param name="numberOfCharacters">Antal gange tegnet skal gentages</param>
	    /// <returns>En tekst bestående af tegnet gentaget med foranstående mellemrum</returns>
	    public string GetStringOfCharactersWithSpacesBefore(char characterToRepeat, int spacesBefore, int numberOfCharacters)
		{
			return "";
		}


		/// <summary>
		/// OPGAVE 7:
		/// 
		/// Vi ønsker dette præcise output:
		/// 
		///	     *
		///     ***
		///    *****
		///   *******
		///  *********
		/// ***********
		///      *
		/// 
		/// HINT: Linieskift indsættes med koden "<br/>".
		/// 
		/// </summary>
		/// <returns>Et juletræ</returns>
	    public string GetChristmasTree()
		{
			return "";
		}

		/// <summary>
		/// OPGAVE 8:
		/// 
		/// Ud fra en alder ønskes ét af tre mulige outputs: "Ikke myndig", "Voksen" eller "Pensionist".
		/// 
		/// Personer mellem 0 og 17 (begge inklusive) er ikke myndige. Mellem 18 og 64 er de voksne. Fra 65 er de pensionister.
		/// </summary>
		/// <param name="age">En alder</param>
		/// <returns>En tekst der beskriver borgerens type</returns>
	    public string GetCitizenType(int age)
		{
			return "";
		}

		/// <summary>
		/// OPGAVE 9:
		/// 
		/// Ud fra en liste ønsker vi en ny liste med den omvendte rækkefølge.
		/// </summary>
		/// <param name="list">En liste af tekster</param>
		/// <returns>Den omvendte liste</returns>
		public List<string> ReverseOrderOfList(List<string> list)
		{
			return null;
		}

		/// <summary>
		/// OPGAVE 10:
		/// 
		/// Givet en liste over farver, og en liste over frugter, ønsker vi en kombineret liste, hvor hvert element er en
		/// farve og den tilsvarende frugt.
		/// 
		/// Eksempel: GetColoredFruits(new List { "Green", "Yellow", "Red" }, new List { "Kiwi", "Banana", "Apple" })  =>  List { "Green Kiwi", "Yellow Banana", "Red Apple" }
		/// </summary>
		/// <param name="colors">En liste over farver</param>
		/// <param name="fruits">En liste over frugter</param>
		/// <returns>En liste over farvede frugter</returns>
	    public List<string> GetColoredFruits(List<string> colors, List<string> fruits)
		{
			return null;
		} 

		/// <summary>
		/// OPGAVE 11:
		/// 
		/// Betragt klassen Grocery herunder. Givet en liste indeholdende Groceries, ønskes den samlede pris for alle varer.
		/// </summary>
		/// <param name="shoppingList">Indkøbslisten</param>
		/// <returns>Den samlede pris</returns>
	    public int GetPriceForGroceries(List<GroceryItem> shoppingList)
	    {
		    return 0;
	    }

		/// <summary>
		/// OPGAVE 12:
		/// 
		/// Givet penge på lommen og en shoppingliste, ønskes at vide, om vi har penge nok.
		/// </summary>
		/// <param name="money">Penge på lommen</param>
		/// <param name="shoppingList">Indkøbslisten</param>
		/// <returns>Sandt eller falsk</returns>
	    public bool HasEnoughMoneyToBuyStuff(int money, List<GroceryItem> shoppingList)
	    {
		    return false;
	    }

		/// <summary>
		/// OPGAVE 13:
		/// 
		/// Givet en indkøbsliste, ønskes en pæn præsentationstekst på følgende form:
		/// 
		/// "Indkøb: æg, smør, brød, ost = 45 kr."
		/// </summary>
		/// <param name="shoppingList">Indkøbslisten</param>
		/// <returns>Et pænt resumé</returns>
	    public string SummaryLine(List<GroceryItem> shoppingList)
		{
			return "";
		}

		/// <summary>
		/// OPGAVE 14:
		/// 
		/// Givet en vilkårlig dato ønskes det danske navn for ugedagen.
		/// </summary>
		/// <param name="date">En DateTime sat til en hvilken-som-helst dato</param>
		/// <returns>En dansk ugedag som tekst</returns>
		public string DanishWeekday(DateTime date)
		{
			return "";
		}

		/// <summary>
		/// OPGAVE 15:
		/// 
		/// En pæn opstilling af alle runde fødselsdage ud fra den faktiske fødedag, sammen med den danske ugedag for fødselsdagen.
		/// </summary>
		/// <param name="birthday">En DateTime sat til en given persons fødselsdag</param>
		/// <returns>En tekst, der viser alle runde fødselsdage, og den tilhørende danske ugedag</returns>
	    public string WeekdaysOfMyRoundBirthdays(DateTime birthday)
		{
			return null;
		}
	}

	public class GroceryItem
	{
		public string Product { get; set; }
		public int Price { get; set; }
	}
}

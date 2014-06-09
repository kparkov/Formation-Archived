using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using FormationGame.Tools;

namespace FormationGame.Controllers
{
    public class Exercise2Controller : FormationBaseController
    {
        //
        // GET: /Exercise2/

        public ActionResult Index()
        {
	        var names = new List<string> {"Andersine", "Anders", "Rip", "Rap", "Rup"};


	        return ShowObjects(new
	        {
		        AndStrings = AndStrings("Gøg", "Gokke"),
				BeginningOfList = GetNoOfElementsFromBeginning(names, 2),
				EndOfList = GetNoOfElementsFromEnd(names, 3),
				NaturalList = NaturalList(names),
				DeckOfCards  = GetDeckOfCards(),
				RandomCard = PickRandomCard(GetDeckOfCards()),
				ShuffledDeck = ShuffleDeck(GetDeckOfCards()),
				RandomHand = GetRandomHand(GetDeckOfCards(), 13),
				NoOfAKind = NoOfAKind("H", GetRandomHand(GetDeckOfCards(), 13))
	        });
        }

		/// <summary>
		/// To strenge ønskes sammenføjet i en enkelt streng, samlet af et "og"
		/// </summary>
		/// <param name="a">Første ord</param>
		/// <param name="b">Andet ord</param>
		/// <returns>Den sammenføjede streng</returns>
	    public string AndStrings(string a, string b)
		{
			return null;
		}

	    /// <summary>
	    /// Givet en række tekster, ønsker vi en ny liste, der kun indeholder de første noOfElements. Hvis noOfElements er
	    /// større end listens antal, skal hele listen returneres.
	    /// </summary>
	    /// <param name="list">Den oprindelige liste</param>
	    /// <param name="noOfElements">Antal elementer, der skal medtages fra starten</param>
	    /// <returns>Den nye, begrænsede liste</returns>
	    public List<string> GetNoOfElementsFromBeginning(List<string> list, int noOfElements)
	    {
		    return null;
	    }

		/// <summary>
		/// Givet en række tekster, ønsker vi en ny liste, der kun indeholder de sidste noOfElements. Hvis noOfElements er
		/// større end listens antal, skal hele listen returneres.
		/// </summary>
		/// <param name="list">Den oprindelige liste</param>
		/// <param name="noOfElements">Antal elementer, der skal medtages fra slutningen</param>
		/// <returns>Den nye, begrænsede liste</returns>
	    public List<string> GetNoOfElementsFromEnd(List<string> list, int noOfElements)
	    {
		    return null;
	    }

		/// <summary>
		/// Givet en liste af tekster, ønsker vi dem sammenføjet som en naturlig opremsning, hvor komma
		/// separerer alle elementer, men de to sidste er samlet af et "og".
		/// 
		/// Eksempel: NaturalList(new List {"Hest", "Bil", "Cykel", "Tog"} => "Hest, Bil, Cykel og Tog"
		/// </summary>
		/// <param name="listOfWords">listen af tekster</param>
		/// <returns>Den naturlige opremsning som en tekst</returns>
	    public string NaturalList(List<string> listOfWords)
		{
			return null;
		}

		/// <summary>
		/// Betragt denne klasse til brug for de følgende opgaver.
		/// </summary>
	    public class PlayingCard
	    {
		    public string Color { get; set; }
		    public string Value { get; set; }
	    }

		/// <summary>
		/// Vi ønsker at danne et sæt spillekort.
		/// 
		/// Der er 4 farver (H, K, S, R) og 13 værdier (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, B, D, K).
		/// 
		/// Listen skal indeholde alle kombinationer af en farve og en værdi.
		/// </summary>
		/// <returns>En liste af PlayingCards</returns>
	    public List<PlayingCard> GetDeckOfCards()
		{
			return null;
		}

		/// <summary>
		/// Vi ønsker to effekter:
		/// 
		/// - metoden skal returnere et tilfældigt kort fra listen over kort.
		/// - Det returnerede kort skal fjernes fra listen.
		/// 
		/// HINT: Tilfældige tal kan dannes ved hjælp af klassen RandomNumberGenerator
		/// 
		/// </summary>
		/// <param name="deck">Et spil kort</param>
		/// <returns>Et tilfældigt kort</returns>
	    public PlayingCard PickRandomCard(List<PlayingCard> deck)
		{
			return null;
		}

		/// <summary>
		/// Givet et spil kort, ønsker vi et tilfældigt blandet sæt tilbage.
		/// </summary>
		/// <param name="deck">Et spil kort</param>
		/// <returns>Et blandet spil kort</returns>
	    public List<PlayingCard> ShuffleDeck(List<PlayingCard> deck)
		{
			return null;
		}

		/// <summary>
		/// Vi ønsker at trække en tilfældig hånd med et valgfrit antal kort.
		/// </summary>
		/// <param name="deck">Et spil kort</param>
		/// <returns>En tilfældig hånd</returns>
	    public List<PlayingCard> GetRandomHand(List<PlayingCard> deck, int noOfCardsToDraw)
	    {
		    return null;
	    }

		 

		/// <summary>
		/// Givet en farve (H, K, S, R) og en tilfældig hånd, ønskes en optælling af, hvor mange kort på hånden, der har den
		/// givne farve.
		/// </summary>
		/// <param name="color">En farve</param>
		/// <param name="hand">En tilfældig hånd</param>
		/// <returns>Antal kort på hånden af farven</returns>
	    public int NoOfAKind(string color, List<PlayingCard> hand)
		{
			return 0;
		}

		/// <summary>
		/// Givet en tilfældig hånd, ønskes den/de farve(r), som er repræsenteret ved det højeste antal kort. Hvis flere farver
		/// er repræsenteret med lige mange kort, skal de skrives som en naturlig opremsning.
		/// </summary>
		/// <param name="hand">En tilfældig hånd</param>
		/// <returns>En opremsning af de dominerende farver</returns>
	    public string DominatingColors(List<PlayingCard> hand)
	    {
		    return null;
	    }



    }
}

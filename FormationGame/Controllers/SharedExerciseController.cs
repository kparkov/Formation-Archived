using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
    public class SharedExerciseController : FormationBaseController
    {
	    public ActionResult Index()
	    {
		    return Content("");
	    }

		// Fælles opgave løsning
		// START

        public string GetHattefarsWeekday(DateTime birthday)
        {
            // Tæl frem til nærmeste skudår med udgangspunkt i birthday (GetFirstLeapYear)
            int year = birthday.Year;

            int firstLeapYear = GetFirstLeapYear(year);

            // Vi skal generere en DateTime for fødselsdagen i skudåret
            DateTime birthdayInFirstLeapYear = new DateTime(firstLeapYear, birthday.Month, birthday.Day);

            // Ud fra ovenstående skal vi tælle 2 måneder, 3 uger og 4 dage frem.
            var dayWithOffset = birthdayInFirstLeapYear.AddMonths(2).AddDays((7 * 3) + 4);

            // Vi skal finde ud af om det er sommerhalvår eller vinterhalvår.
            if (dayWithOffset.Month > 3 && dayWithOffset.Month < 10)
            {
                return GetHattefarsSummerWeekday((int)dayWithOffset.DayOfWeek);
            }
            else
            {
                return GetHattefarsWinterWeekday((int)dayWithOffset.DayOfWeek);
            }
        }

        public int GetFirstLeapYear(int year)
        {
            // Begynd en løkke
            while (!IsLeapYear(year))
            {
                year++;
            }

            return year;
        }

        public bool IsLeapYear(int year)
        {
            // Lav en ny Datetime, som er sat til 31 / 12 / year
            var test3112 = new DateTime(year, 12, 31);

            // Hvis det er 366
            if (test3112.DayOfYear == 366)
            {
                // Så er det skudår! returner true
                return true;
            }
            else
            {
                // Så er det ikke skudår! returner false
                return false;
            }
        }

        /// <summary>
        /// Returnerer hattefars sommerugedag
        /// </summary>
        /// <param name="weekday">Ugedagen som tal mellem 0 og 6 (hvor 0 er søndag)</param>
        /// <returns>Ugedagsnavn som tekst</returns>
        public string GetHattefarsSummerWeekday(int weekday)
        {
            // Lav en liste med sommernavnene
            var summerDayList = new List<string>() { 
                "Stener-dag",
                "Uz-dag",
                "Hep-dag",
                "Hola-dag",
                "Weee-dag",
                "Sådan-dag",
                "Party-dag",
            };

            // Returnér teksten med index = weekday
            return summerDayList[weekday];
        }

        public string GetHattefarsWinterWeekday(int weekday)
        {
            // Lav en liste med vinternavnene
            var winterDayList = new List<string>() { 
                "Stener-dag",
                "Ad-dag",
                "Hrøm-dag",
                "Grøf-dag",
                "Trøste-dag",
                "Hey-dag",
                "Super-dag",
            };

            // Returnér teksten med index = weekday
            return winterDayList[weekday];
        }

		// SLUT

    }
}

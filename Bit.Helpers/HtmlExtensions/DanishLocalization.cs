using System;
using System.Globalization;
using System.Web.Mvc;

namespace Bit.Helpers.HtmlExtensions
{
    public static class DanishLocalization
    {
        public static string DanishShortMonthName<TModel>(this HtmlHelper<TModel> helper, DateTime dt)
        {
            return ((new CultureInfo("DA-dk")).DateTimeFormat).GetAbbreviatedMonthName(dt.Month);
        }

        public static string DanishDayOfWeek<TModel>(this HtmlHelper<TModel> helper, DateTime dt)
        {
            string dayname = ((new CultureInfo("DA-dk")).DateTimeFormat).GetAbbreviatedDayName(dt.DayOfWeek);

            string capitalized = dayname.Substring(0, 1).ToUpper() + dayname.Substring(1);

            return capitalized;
        }

        public static string ReaderFriendlyDanishDate<TModel>(this HtmlHelper<TModel> helper, DateTime dt)
        {
            return DanishDayOfWeek(helper, dt) + ". d. " + dt.Day + ". " + DanishShortMonthName(helper, dt) + ". " + dt.Year;
        }

        public static string ReaderFriendlyFullDanishDate<TModel>(this HtmlHelper<TModel> helper, DateTime dt)
        {
            return DanishDayOfWeek(helper, dt) + "., d. " + dt.Day + ". " + DanishShortMonthName(helper, dt) + ". " + dt.Year + ", kl. " + dt.Hour;
        }

        public static string DanishShortFull<TModel>(this HtmlHelper<TModel> helper, DateTime dt)
        {
            return helper.ZeroPrefixing(dt.Day) + " " + DanishShortMonthName(helper, dt) + " " + dt.Year;
        }

	    public static string DanishDecimal(this int? number)
	    {
		    return DanishDecimal(number.GetValueOrDefault());
	    }

	    public static string DanishDecimal(this int number)
	    {
		    return DanishDecimal((decimal) number);
	    }

	    public static string DanishDecimal(this decimal number)
	    {
		    return number.ToString("#,#");
	    }

        public static string DanishTimeAgo<TModel>(this HtmlHelper<TModel> helper, DateTime date)
        {
            var offset = DateTime.Now - date;
            var yesterdayBegan = DateTime.Now.AddDays(-1).Date;
            var todayBegan = DateTime.Now.Date;
            var dayNames = new[] {"Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"};

            if (offset.TotalDays > 7)
            {
                return string.Format("{0}, kl. {1}", date.ToString("D"), date.ToString("t"));
            }

            if (date < yesterdayBegan)
            {
                return string.Format("{0}, kl. {1}", dayNames[(int) date.DayOfWeek], date.ToString("t"));
            }

            if (date > yesterdayBegan && date < todayBegan)
            {
                return string.Format("I går kl. {0}", date.ToString("t"));
            }

            if (offset.TotalHours > 1)
            {
                return string.Format("I dag kl. {0}", date.ToString("t"));
            }

            if (offset.TotalMinutes > 1)
            {
                return string.Format("{0} minutter siden (kl. {1})", (int) Math.Floor(offset.TotalMinutes), date.ToString("t"));
            }

            return "Nu";
        }
    }
}

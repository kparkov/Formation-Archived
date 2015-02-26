using System;
using System.Linq;
using System.Web.Mvc;

namespace Bit.Helpers.HtmlExtensions
{
    public static class StringHelpers
    {
        public static string ZeroPrefixing<TModel>(this HtmlHelper<TModel> helper, string numberString, int totalNumberOfDigits = 2)
        {
            int length = numberString.Length;
            int needed = totalNumberOfDigits - length;

            if (needed < 1)
            {
                return numberString;
            }

            string leading = String.Concat(Enumerable.Repeat("0", needed));

            return leading + numberString;
        }

        public static string ZeroPrefixing<TModel>(this HtmlHelper<TModel> helper, int number, int totalNumberOfDigits = 2)
        {
            return ZeroPrefixing(helper, number.ToString(), totalNumberOfDigits);
        }
    }
}

using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Bit.Helpers.HtmlExtensions
{
    public static class JavascriptHelpers
    {
        public static string JsValue<TModel>(this HtmlHelper<TModel> helper, int value)
        {
            return value.ToString();
        }

        public static MvcHtmlString JsValue(this HtmlHelper helper, string value)
        {
            return MvcHtmlString.Create("\"" + value + "\"");
        }

        public static string JsValue(this HtmlHelper helper, decimal? value)
        {
            if (value.HasValue)
            {
                return value.GetValueOrDefault().ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return "null";
            }
        }

        public static string JsValue(this HtmlHelper helper, bool? value)
        {
            if (value.GetValueOrDefault())
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static IHtmlString ToJsObject(this HtmlHelper helper, object anonymousObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return MvcHtmlString.Create(serializer.Serialize(anonymousObject));
        }

        public static IHtmlString ToJsObject(this HtmlHelper helper, IEnumerable<object> anonymousObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return MvcHtmlString.Create(serializer.Serialize(anonymousObject));
        }
    }
}
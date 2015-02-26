using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Bit.Helpers.HtmlExtensions
{
	public static class PartialHelpers
	{
		public static MvcHtmlString PartialWithPrefix(this HtmlHelper helper, string viewName, object model)
		{
			return helper.Partial(viewName, model, new ViewDataDictionary() {TemplateInfo = new TemplateInfo() {HtmlFieldPrefix = helper.ViewData.TemplateInfo.HtmlFieldPrefix}});
		}

		public static MvcHtmlString PartialWithPrefix(this HtmlHelper helper, string viewName, object model, string prefix)
		{
			return helper.Partial(viewName, model, new ViewDataDictionary() { TemplateInfo = new TemplateInfo() { HtmlFieldPrefix = prefix } });
		}

        public static MvcHtmlString PartialWithPrefix(this HtmlHelper helper, string viewName, object model, object viewDataAttributes)
        {
            var newviewdata = new ViewDataDictionary(helper.ViewData)
            {
                TemplateInfo = new TemplateInfo()
                {
                    HtmlFieldPrefix = helper.ViewData.TemplateInfo.HtmlFieldPrefix
                }
            };

            foreach (var property in viewDataAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var name = property.Name;
                var value = property.GetValue(viewDataAttributes);

                newviewdata.Add(name, value);
            }

            return helper.Partial(viewName, model, newviewdata);
        }
	}
}

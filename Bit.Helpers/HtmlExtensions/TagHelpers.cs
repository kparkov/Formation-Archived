using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Bit.Helpers.HtmlHelpers;
using Bit.Helpers.Reflection;

namespace Bit.Helpers.HtmlExtensions
{
	public static class TagHelpers
	{
		public static SelfDisposingTag CreateSelfDisposingTag(this HtmlHelper helper, string tag, Dictionary<string, string> attributes)
		{
			return new SelfDisposingTag(helper, tag, attributes);
		}

		public static SelfDisposingTag CreateSelfDisposingTag(this HtmlHelper helper, string tag, object attributes)
		{
			var dict = attributes.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(x => x.Name, x => (string) x.GetValue(attributes));

			return CreateSelfDisposingTag(helper, tag, dict);
		}

		public static SelfDisposingTag CreateSelfDisposingTag(this HtmlHelper helper, string tag, Dictionary<string, List<string>> attributes)
		{
			var dict = attributes.ToDictionary(x => x.Key, x => String.Join(" ", x.Value));

			return CreateSelfDisposingTag(helper, tag, dict);
		}

	    public static MvcHtmlString SelectOption(this HtmlHelper helper, string value, string text, bool selected)
	    {
	        var b = new TagBuilder("option");

            b.MergeAttribute("value", value);
	        b.InnerHtml = text;

            if (selected) b.MergeAttribute("selected", "selected");

            return MvcHtmlString.Create(b.ToString());
	    }

	    public static MvcHtmlString SelectOption<TModel>(this HtmlHelper helper, TModel model, Expression<Func<TModel, object>> value, Expression<Func<TModel, object>> text, Func<TModel, bool> selected)
	    {
	        return SelectOption(helper, value.Compile()(model).ToString(), text.Compile()(model).ToString(), selected(model));
	    }

	    public static MvcHtmlString SelectOptions<TModel>(this HtmlHelper helper, IEnumerable<TModel> models, Expression<Func<TModel, object>> value, Expression<Func<TModel, object>> text, Func<TModel, bool> selected)
	    {
	        var b = new StringBuilder();

	        foreach (var model in models)
	        {
	            b.Append(SelectOption(helper, model, value, text, selected));
	        }

            return MvcHtmlString.Create(b.ToString());
	    }

	    public static MvcHtmlString SelectOptions<TModel, TKey, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> property, Dictionary<TKey, TValue> models, Func<KeyValuePair<TKey, TValue>, bool> selected)
	    {
	        return SelectOptions(helper, models, x => x.Key, x => x.Value, selected);
	    }

	    public static MvcHtmlString Select(this HtmlHelper helper, string name, object attributes = null, string options = null, string id = null)
	    {
	        var b = new TagBuilder("select");

            b.MergeAttribute("name", name);

            if (id != null) b.MergeAttribute("id", id);

            b.MergeAttributes(attributes);

	        b.InnerHtml = options;

            return MvcHtmlString.Create(b.ToString());
	    }

	    public static MvcHtmlString Select<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> property, object attributes = null, string options = null)
	    {
	        var member = ExpressionTools.GetFullMemberName(property).Split('.').Last();
	        var fullname = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(member);

	        return Select(helper, fullname, attributes, options, helper.ViewData.TemplateInfo.GetFullHtmlFieldId(member));
	    }

	    public static void MergeAttributes(this TagBuilder builder, object attributes)
	    {
	        if (attributes != null)
	        {
                foreach (var property in attributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var value = property.GetValue(attributes);

                    if (value == null) continue;

                    if (property.Name == "class")
                    {
                        value.ToString().Split(' ').ToList().ForEach(builder.AddCssClass);
                    }
                    else
                    {
                        builder.MergeAttribute(property.Name.Replace('_', '-'), value.ToString());
                    }
	            }
	        }
	    }
	}
}

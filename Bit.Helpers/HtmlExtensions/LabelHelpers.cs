using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Bit.Helpers.Reflection;

namespace Bit.Helpers.HtmlExtensions
{
	public static class LabelHelpers
	{
		public static string LabelForTarget<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> memberExpression)
		{
			var prefix = helper.ViewData.TemplateInfo.HtmlFieldPrefix;

			if (!String.IsNullOrEmpty(prefix))
			{
				prefix = prefix + "_";
			}

			var fullMemberName = ExpressionTools.GetFullMemberName(memberExpression);
			var fullMemberId = fullMemberName.Replace('.', '_');
			
			return prefix + fullMemberId;
		}

		public static MvcHtmlString LabelWrappedEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> memberExpression, string label = null)
		{
			var editor = helper.EditorFor(memberExpression).ToString();

			var template = "<label for=\"{0}\">{1}{2}</label>";

			var forAttribute = LabelForTarget(helper, memberExpression);

			label = label ?? forAttribute.Split('.').Last();

			var result = String.Format(template, forAttribute, label, editor);

			return MvcHtmlString.Create(result);
		}
	}
}

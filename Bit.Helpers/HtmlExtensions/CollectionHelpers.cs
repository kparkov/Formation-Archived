using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Bit.Helpers.Reflection;

namespace Bit.Helpers.HtmlExtensions
{
	public static class CollectionHelpers
	{
		private const string ContextKey = "BitHtmlCollectionCounter";

		public static void BeginCollectionCounter(this HtmlHelper helper)
		{
			helper.ViewContext.HttpContext.Items.Remove(ContextKey);
			helper.ViewContext.HttpContext.Items.Add(ContextKey, 0);
		}

		public static int GetCollectionCount(this HtmlHelper helper)
		{
			var items = helper.ViewContext.HttpContext.Items;

			if (!items.Contains(ContextKey) || !(items[ContextKey] is int))
			{
				BeginCollectionCounter(helper);
			}

			var counter = (int) items[ContextKey];

			var currentCount = counter;

			items[ContextKey] = counter + 1;

			return currentCount;
		}

		public static int GetSameCollectionCount(this HtmlHelper helper)
		{
			var items = helper.ViewContext.HttpContext.Items;

			if (!items.Contains(ContextKey) || !(items[ContextKey] is int))
			{
				BeginCollectionCounter(helper);
			}

			return ((int)items[ContextKey] - 1);
		}
	}
}

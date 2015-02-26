using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bit.Helpers.HtmlHelpers
{
	public class SelfDisposingTag : IDisposable
	{
		protected HtmlHelper Helper { get; set; }
		protected TagBuilder Builder { get; set; }

		public SelfDisposingTag(HtmlHelper helper, string tag, Dictionary<string, string> attributes)
		{
			Helper = helper;

			Builder = new TagBuilder(tag);

			Builder.MergeAttributes(attributes);

			Helper.ViewContext.Writer.Write(Builder.ToString(TagRenderMode.StartTag));
		}

		public void Dispose()
		{
			Helper.ViewContext.Writer.Write(Builder.ToString(TagRenderMode.EndTag));
		}
	}
}

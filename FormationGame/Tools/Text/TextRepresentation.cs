using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace FormationGame.Tools.Text
{
	public class TextRepresentation
	{
		public MvcHtmlString DisplayObject(object obj)
		{
			return MvcHtmlString.Create(ParseRootObject(obj));
		}

		protected string ParseEnumerable(IEnumerable list)
		{
			var listItems = new List<string>();

			foreach (var obj in list)
			{
				listItems.Add(ParseRootObject(obj));
			}

			return String.Join("", listItems);
		}

		protected string ParseRootObject(object obj)
		{
			if (obj == null)
			{
				return "<em>[null]</em>";
			}

			if (obj is IEnumerable)
			{
				return ParseEnumerable((IEnumerable)obj);
			}

			if (IsPrimitiveType(obj.GetType()))
			{
				return obj.ToString();
			}

			var objectName = "<h3>" + obj.GetType().Name + "</h3>";

			var list = new List<string>();

			foreach (var propertyInfo in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				var propertyName = propertyInfo.Name;
				var value = ParseRootObject(propertyInfo.GetGetMethod().Invoke(obj, new object[] {}));

				var formatted = String.Format("<li><strong>{0}</strong>: {1}</li>", propertyName, value);

				list.Add(formatted);
			}

			return objectName + "<ul>" + String.Join("", list) + "</ul>";
		}

		protected bool IsPrimitiveType(Type t)
		{
			var primitives = new List<Type>()
			{
				typeof(Decimal), typeof(String), typeof(Int32), typeof(Int16), typeof(Int64), typeof(Boolean),
				typeof(Nullable), typeof(DateTime)
			};

			return t.IsPrimitive || primitives.Contains(t);
		}
	}
}
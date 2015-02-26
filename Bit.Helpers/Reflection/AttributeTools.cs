using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bit.Helpers.Reflection
{
	public class AttributeTools
	{
		public static TAttribute GetAttribute<TClass, TAttribute>(Expression<Func<TClass, object>> memberExpression)
		{
			return GetAttributes<TClass, TAttribute>(memberExpression).FirstOrDefault();
		}

		/// <summary>
		/// Returns the list of TAttributes, decorating a TClass member 
		/// </summary>
		/// <typeparam name="TClass">The type of the object to inspect</typeparam>
		/// <typeparam name="TAttribute">The type of the attributes to return</typeparam>
		/// <param name="memberExpression">The member decorated</param>
		/// <returns>An enumerable of attributes of the given type</returns>
		public static IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(Expression<Func<TClass, object>> memberExpression)
		{
			var propertyName = ExpressionTools.GetMemberExpression(memberExpression).Member.Name;
			var property = typeof (TClass).GetProperty(propertyName);
			var attributes = property.GetCustomAttributes(typeof (TAttribute), false).Cast<TAttribute>();
			return attributes;
		}

		public static TAttribute GetAttribute<TClass, TAttribute>()
		{
			return GetAttributes<TClass, TAttribute>().FirstOrDefault();
		}

		public static IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>()
		{
			var attributes = typeof (TClass).GetCustomAttributes(typeof (TAttribute), false).Cast<TAttribute>();
			return attributes;
		}
	}
}

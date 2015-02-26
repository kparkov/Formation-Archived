using System.Collections.Generic;
using System.Web.Mvc;

namespace Bit.Helpers.HtmlExtensions
{
	public static class AttributeHelpers
	{
		public static Dictionary<string, object> TakesDataAttributes<TModel>(this HtmlHelper<TModel> helper, params object[] additionalValues)
		{
			var viewData = helper.ViewData.ModelMetadata.AdditionalValues;

			var result = new Dictionary<string, object>();

			foreach (var keyValuePair in viewData)
			{
				if (keyValuePair.Key.StartsWith("data_"))
				{
					result.Add(keyValuePair.Key.Replace("_", "-"), keyValuePair.Value);
				}
			}

			foreach (var additionalObject in additionalValues)
			{
				if (additionalObject != null)
				{
					foreach (var property in additionalObject.GetType().GetProperties())
					{
						string keyName = property.Name.Replace("_", "-");

						if (result.ContainsKey(keyName))
						{
							result[keyName] = result[keyName] + " " + property.GetValue(additionalObject, null);
						}
						else
						{
							result.Add(keyName, property.GetValue(additionalObject, null));
						}
					}
				}
			}

			return result;
		}
	}
}

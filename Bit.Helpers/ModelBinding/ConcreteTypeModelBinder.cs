using System;
using System.Web.Mvc;
using Bit.Helpers.ModelBinding;

namespace SIB.WebCommon.ModelBinding
{
	public class ConcreteTypeModelBinder : DefaultModelBinder
	{
		protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
		{
            if (!typeof(IExposesConcrete).IsAssignableFrom(modelType)) throw new ArgumentException("The model must implement IExposesConcrete to be properly sub-binded.");

			string fieldName = String.IsNullOrEmpty(bindingContext.ModelName) ? "ConcreteType" : bindingContext.ModelName + ".ConcreteType";

		    if (bindingContext.ValueProvider.GetValue(fieldName) == null) return null;

			string concreteType = (string) bindingContext.ValueProvider.GetValue(fieldName).ConvertTo(typeof(string));

			if (concreteType == null) return base.CreateModel(controllerContext, bindingContext, modelType);

			var type = Type.GetType(concreteType);

			var model = Activator.CreateInstance(type);
			bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, type);
			bindingContext.ModelMetadata.Model = model;

			return model;
		}
	}
}
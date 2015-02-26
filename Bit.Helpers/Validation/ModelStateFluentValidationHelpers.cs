using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Bit.Helpers.Reflection;
using FluentValidation;
using FluentValidation.Results;

namespace Bit.Helpers.Validation
{
	public static class ModelStateFluentValidationHelpers
	{
		public static ValidationResult FluentValidateModel<TModel>(this ModelStateDictionary modelState, AbstractValidator<TModel> validator, TModel viewModel)
		{
			var result = validator.Validate(viewModel);

			foreach (var validationFailure in result.Errors)
			{
				modelState.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);
			}

			return result;
		} 

		public static ValidationResult FluentValidateModelProperty<TModel, TProperty>(this ModelStateDictionary modelState, AbstractValidator<TProperty> validator, TModel viewModel, Expression<Func<TModel, object>> memberExpression)
		{
			var memberName = ExpressionTools.GetFullMemberName(memberExpression);
			var property = memberExpression.Compile()(viewModel);

			if (!(property is TProperty)) return null;

			var result = validator.Validate((TProperty)property);

			foreach (var validationFailure in result.Errors)
			{
				modelState.AddModelError(memberName + "." + validationFailure.PropertyName, validationFailure.ErrorMessage);
			}

			return result;
		}
	}
}

using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using FluentValidation.Results;

namespace Bit.Helpers.Validation
{
    public class ValidateModelWith : ActionFilterAttribute
    {
        public string ParameterName { get; set; }
        public Type Validator { get; set; }

        public ValidateModelWith()
        {
            Validator = null;
            Order = 0;
            ParameterName = "model";
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var model = filterContext.ActionParameters[ParameterName];

            object validatorInstance;

            if (Validator == null)
            {
                var qualifiedTypeName = model.GetType().AssemblyQualifiedName;

                var split = qualifiedTypeName.Split(',').Select(x => x.Trim()).ToList();
                var guessedTypeName = split.First() + "Validator, " + string.Join(", ", split.Skip(1));

                var guessedValidator = Type.GetType(guessedTypeName);

                if (guessedValidator == null)
                {
                    throw new Exception("The validator type was not specified, and the inferred type did not exist: " + guessedTypeName);
                }

                validatorInstance = Activator.CreateInstance(guessedValidator, new object[] {});
            }
            else
            {
                validatorInstance = Activator.CreateInstance(Validator, new object[] { });
            }
            
            MethodInfo validateMethod = validatorInstance.GetType().GetMethod("Validate", new []{ model.GetType() });

            ValidationResult result = (ValidationResult) validateMethod.Invoke(validatorInstance, new[] {model});

            var modelState = filterContext.Controller.ViewData.ModelState;

            foreach (var error in result.Errors)
            {
                modelState.AddModelError((string) error.PropertyName, (string) error.ErrorMessage);
            }
        }
    }
}
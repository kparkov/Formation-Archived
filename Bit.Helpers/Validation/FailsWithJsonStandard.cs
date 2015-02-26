using System.Web.Mvc;
using Bit.Helpers.Json;

namespace Bit.Helpers.Validation
{
    public class FailsWithJsonStandard : ActionFilterAttribute
    {
        public string Feedback { get; set; }

        public FailsWithJsonStandard(string feedback = null)
        {
            Order = 100;
            Feedback = feedback;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;

            if (!modelState.IsValid)
            {
                filterContext.Result = JsonStandardResult.Error(modelState, Feedback);
            }
        }
    }
}
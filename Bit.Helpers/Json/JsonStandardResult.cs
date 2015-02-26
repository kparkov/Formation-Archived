using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bit.Helpers.Json
{
	public class JsonStandardResult : ActionResult
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public JsonResultStatus Status { get; set; }

		public string FeedbackMessage { get; set; }

		public object Result { get; set; }

		public Dictionary<string, List<string>> Errors { get; set; }

		public JsonStandardResult()
		{
		}

		public static JsonStandardResult Success(object result = null, string feedback = null)
		{
			return new JsonStandardResult() {Status = JsonResultStatus.Success, Result = result, FeedbackMessage = feedback};
		}

		public static JsonStandardResult Failure(string feedback = null)
		{
			return new JsonStandardResult() {Status = JsonResultStatus.Failure, FeedbackMessage = feedback};
		}

		public static JsonStandardResult Error(Dictionary<string, List<string>> errors, string feedback = null)
		{
			return new JsonStandardResult() {Status = JsonResultStatus.Error, Errors = errors, FeedbackMessage = feedback};
		}

		public static JsonStandardResult Error(ModelStateDictionary modelState, string feedback = null)
		{
			return new JsonStandardResult() {Status = JsonResultStatus.Error, Errors = modelState.Where(x => x.Value.Errors.Any()).ToDictionary(x => x.Key, x => Enumerable.ToList<string>(x.Value.Errors.Select(y => y.ErrorMessage))), FeedbackMessage = feedback};
		}

		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.ContentType = "application/json";
			context.HttpContext.Response.Write(JsonConvert.SerializeObject(this, new JsonSerializerSettings() { }));
		}
	}
}
using System.Configuration;

namespace Bit.Helpers
{
	public static class Debugging
	{
		public static bool IsDebugMode()
		{
#if DEBUG
			return true;
#else
			return false;
#endif
		}

	    public static bool IsTestMode()
	    {
	        try
	        {
	            var testmode = bool.Parse(ConfigurationManager.AppSettings["Bit.TestMode"]);
	            return testmode;
	        }
	        catch
	        {
	            return false;
	        }
	    }
	}
}

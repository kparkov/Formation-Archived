using System.Data.Entity;
using System.Web;
using BitFrame;
using BitFrame.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof($rootnamespace$.BitFrameConfig), "Start")]

namespace $rootnamespace$
{
	public class BitFrameConfig
	{
		public static void Start()
		{
			Database.SetInitializer<BitStore>(new DropCreateDatabaseIfModelChanges<BitStore>());

			BitCore.Builder = new MvBitCoreBuilder();

			var bit = BitCore.Instance;

			bit.Files.ApplicationRootDirectory = HttpContext.Current.Server.MapPath("~");
			bit.Files.RelativeFileDirectory = @"App_Data\Uploads\";
			bit.Files.CreateAbsoluteFileDirectoryIfNotExists();
		}
	}
}
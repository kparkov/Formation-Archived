using System.Data.Entity;
using BitFrame.Models;
using FormationGame.Models;

namespace FormationGame.Store
{
	public class FormationStore : BitStore
	{
		public DbSet<TestModel> TestModels { get; set; }

		public FormationStore(string connectionString) : base(connectionString)
		{
		}
	}
}
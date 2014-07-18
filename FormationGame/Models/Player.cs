using BitFrame.Models;

namespace FormationGame.Models
{
	public class Player : BaseModel
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
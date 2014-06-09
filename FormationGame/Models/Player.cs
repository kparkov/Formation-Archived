using System.Collections.Generic;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class Player : BaseModel
	{
		public virtual ICollection<Game> Games { get; set; } 
	}
}
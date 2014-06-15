using System.Collections.Generic;
using BitFrame.Models;
using Newtonsoft.Json;

namespace FormationGame.Models
{
	public class Player : BaseModel
	{
		[JsonIgnore]
		public virtual ICollection<Game> Games { get; set; } 
	}
}
using System.Linq;
using BitFrame.Models;
using Newtonsoft.Json;

namespace FormationGame.Models
{
	public enum MoveType
	{
		Push,
		Jump,
		Split,
		Switch,
		Boost,
		Fourify,
		Match,
		Destroy
	}

	public enum MoveDirection
	{
		Up,
		Down
	}

	public class Move : BaseModel
	{
		[JsonIgnore]
		public virtual Game Game { get; set; }

		public MoveType Type { get; set; }
		public int Position { get; set; }
		public MoveDirection Direction { get; set; }

		#region NavigationHelperProperties

		[JsonIgnore]
		public virtual GameState PrecedingGameState
		{
			get
			{
				var moves = Game.Moves.ToList();

				var moveIndex = moves.IndexOf(this);

				return Game.GameStates.ToList()[moveIndex];
			}
		}

		[JsonIgnore]
		public virtual GameState SucceedingGameState
		{
			get
			{
				var moves = Game.Moves.ToList();

				var moveIndex = moves.IndexOf(this);

				if (Game.GameStates.Count() <= moveIndex)
				{
					return null;
				}

				return Game.GameStates.ToList()[moveIndex + 1];
			}
		}

		#endregion
	}
}
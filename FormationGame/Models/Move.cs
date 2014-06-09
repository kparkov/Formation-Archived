using System.Linq;
using BitFrame.Models;

namespace FormationGame.Models
{
	public class Move : BaseModel
	{
		public virtual Game Game { get; set; }

		#region NavigationHelperProperties

		public virtual GameState PrecedingGameState
		{
			get
			{
				var moves = Game.Moves.ToList();

				var moveIndex = moves.IndexOf(this);

				return Game.GameStates.ToList()[moveIndex];
			}
		}

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

		#region SupportMethods

		public bool IsSameMove(Move otherMove)
		{
			if (otherMove == null)
			{
				return false;
			}

			return this == otherMove;
		}

		#endregion
	}
}
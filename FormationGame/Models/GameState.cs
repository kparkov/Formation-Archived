using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BitFrame.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FormationGame.Models
{
	public class GameState : BaseModel
	{
		[JsonIgnore]
		public virtual Game Game { get; set; }


		// todo: implement needed properties

        public virtual List<Die> BlackDiceRow { get; set; }
        public virtual List<Die> WhiteDiceRow { get; set; }




		/// <summary>
		/// Returns the player to act at this game state.
		/// </summary>
		/// <returns></returns>
		public Player GetActivePlayer()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns the current point score. A negative number is a white lead, a positive number is a black lead
		/// </summary>
		/// <returns></returns>
		public int GetPointScore()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// This static method is called to get an initial starting position.
		/// 
		/// Step 2: should handle (as in never return) any mulligans.
		/// </summary>
		/// <returns></returns>
		public static GameState GetInitialState()
		{
            var state = new GameState();
            state.BlackDiceRow = new List<Die>();
            state.WhiteDiceRow = new List<Die>();

            for (var i = 0; i < 8; i++) 
            {
                var die = new Die();
                die.Roll();
                state.BlackDiceRow.Add(die);
            }
            return state;
		}

		#region NavigationHelperProperties 

		//[JsonIgnore]
		//[NotMapped]
		//public Move PrecedingMove
		//{
		//	get
		//	{
		//		var gameStateIndex = Game.GameStates.IndexOf(this);

		//		if (gameStateIndex == 0)
		//		{
		//			return null;
		//		}

		//		return Game.Moves[gameStateIndex - 1];
		//	}
		//}

		//[JsonIgnore]
		//[NotMapped]
		//public Move SucceedingMove
		//{
		//	get
		//	{
		//		var gameStateIndex = Game.GameStates.IndexOf(this);

		//		if (Game.Moves.Count < Game.GameStates.Count)
		//		{
		//			return null;
		//		}

		//		return Game.Moves[gameStateIndex];
		//	}
		//}

		//[JsonIgnore]
		//[NotMapped]
		//public GameState PrecedingGameState
		//{
		//	get
		//	{
		//		return PrecedingMove.PrecedingGameState;
		//	}
		//}

		//[JsonIgnore]
		//[NotMapped]
		//public GameState SucceedingGameState
		//{
		//	get
		//	{
		//		return SucceedingMove.SucceedingGameState;
		//	}
		//}

		//public bool IsCurrentState
		//{
		//	get { return Game.GameStates.ToList().IndexOf(this) == Game.GameStates.Count() - 1; }
		//}

		//public bool IsInitialGameState
		//{
		//	get { return Game.GameStates.IndexOf(this) == 0; }
		//}

		#endregion
	}
}
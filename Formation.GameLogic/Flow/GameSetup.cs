using System.Collections.Generic;
using Formation.Data.Model;
using Formation.GameLogic.Abstract;
using System.Linq;

namespace Formation.GameLogic.Flow
{
    public class GameBoardFactory : BaseLogic
    {
        public GameBoardFactory(IGameMechanics gameMechanics) : base(gameMechanics)
        {
        }

        public GameState NewBoard()
        {
            var state = new GameState();

            state.WhiteCells = new List<GameBoardCell>() {new Die(), new Die(), new Die(), new Die(), new Die() };
            state.BlackCells = new List<GameBoardCell>() {new Die(), new Die(), new Die(), new Die(), new Die() };

            state.WhiteCells = state.WhiteCells.OfType<Die>().OrderByDescending(x => x.Value).Cast<GameBoardCell>().ToList();
            state.BlackCells = state.BlackCells.OfType<Die>().OrderByDescending(x => x.Value).Cast<GameBoardCell>().ToList();

            state.WhiteCells.Add(new GameBoardCell());
            state.WhiteCells.Add(new GameBoardCell());
            state.WhiteCells = state.WhiteCells.Reverse().ToList();
            state.WhiteCells.Add(new GameBoardCell());
            state.WhiteCells = state.WhiteCells.Reverse().ToList();

            return state;
        }
    }
}
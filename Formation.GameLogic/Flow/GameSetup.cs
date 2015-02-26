using System.Collections.Generic;
using Formation.Data.Model;
using Formation.GameLogic.Abstract;

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

            state.WhiteCells = new List<GameBoardCell>() { new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new Die(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell() };
            state.BlackCells = new List<GameBoardCell>() { new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell(), new GameBoardCell() };

            return state;
        }
    }
}
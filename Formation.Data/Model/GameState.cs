using System.Collections.Generic;
using System.Linq;

namespace Formation.Data.Model
{
    public class GameState : Base
    {
        // White is POSITIVE when counting points
        public virtual ICollection<GameBoardCell> WhiteCells { get; set; }

        // Black is NEGATIVE when counting points
        public virtual ICollection<GameBoardCell> BlackCells { get; set; }

        public GameState()
        {
            WhiteCells = new List<GameBoardCell>();
            BlackCells = new List<GameBoardCell>();
        }

        public int Score()
        {
            return WhiteCells.OfType<Die>().Sum(x => x.Value) - BlackCells.OfType<Die>().Sum(x => x.Value);
        }
    }
}
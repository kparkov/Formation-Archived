using System;
using System.Collections.Generic;
using System.Linq;

namespace Formation.Data.Model
{
    public class Game : Base
    {
        public virtual Player White { get; set; }
        public virtual Player Black { get; set; }

        public virtual ICollection<GameState> States { get; set; }
        public virtual ICollection<Move> Moves { get; set; }

        public Game()
        {
            States = new List<GameState>();
            Moves = new List<Move>();
        }

        public GameState GetCurrentState()
        {
            return States.Last();
        }

        public Player GetFirstToMove()
        {
            return White;
        }

        public Player GetOppositePlayer(Player player)
        {
            if (player != White && player != Black) throw new Exception("That player is not part of this game!");

            if (player == White)
            {
                return Black;
            }

            return White;
        }

        public Player GetActivePlayer()
        {
            var moves = Moves.Count;
            var isEvenNumberOfMoves = (moves % 2) == 0;

            if (isEvenNumberOfMoves)
            {
                return GetFirstToMove();
            }

            return GetOppositePlayer(GetFirstToMove());
        }

        public Player GetPassivePlayer()
        {
            return GetOppositePlayer(GetActivePlayer());
        }
    }
}

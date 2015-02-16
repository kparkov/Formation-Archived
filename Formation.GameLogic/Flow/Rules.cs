using System.Collections.Generic;
using Formation.Data.Model;
using Formation.GameLogic.Abstract;

namespace Formation.GameLogic.Flow
{
    public class Rules : BaseLogic
    {
        public Rules(IGameMechanics gameMechanics) : base(gameMechanics)
        {
        }

        // This is wrong! Any game state is currently considered legal!
        public bool IsLegalGameState(GameState gameState)
        {
            return true;
        }

        // This is wrong! Any game configuration is considered valid and playable!
        public bool IsGameValidAndPlayable(Game game)
        {
            return true;
        }
        
        // This is wrong! Given a state and a move, we currently return... an empty game state???
        public GameState GetNewStateAfterMove(GameState currentState, Move move)
        {
            return new GameState();
        }

        // This is wrong! Any move is considered valid!
        public bool IsValidMove(GameState gameState, Move move)
        {
            return true;
        }

        // This is wrong! Given a state, the given move options are always empty!
        public List<Move> GetOptions(GameState state)
        {
            return new List<Move>();
        }
    }
}
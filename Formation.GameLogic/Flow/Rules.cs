using System;
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
        
        // This is correct! But none of the ApplyMove calls are... :-(
        public GameState GetNewStateAfterMove(GameState currentState, Move move)
        {
            return move.ApplyMove(currentState);
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

        // This is just a utility method - given the name of a move, we construct the relevant object
        public Move GetMoveByName(string name)
        {
            return (Move)Activator.CreateInstance(Type.GetType(name));
        }
    }
}
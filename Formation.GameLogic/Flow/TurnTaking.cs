using System;
using Formation.Data.Model;
using Formation.GameLogic.Abstract;
using Formation.GameLogic.Errors;

namespace Formation.GameLogic.Flow
{
    public class TurnTaking : BaseLogic
    {
        public TurnTaking(IGameMechanics gameMechanics) : base(gameMechanics)
        {
        }

        public Game StartNewGame(string whitePlayerName, string blackPlayerName)
        {
            var white = GameMechanics.Persistence.CreateOrGetPlayer(whitePlayerName);
            var black = GameMechanics.Persistence.CreateOrGetPlayer(blackPlayerName);

            var game = new Game
            {
                White = white,
                Black = black
            };

            var initialState = GameMechanics.GameBoardFactory.NewBoard();

            game.States.Add(initialState);

            if (!GameMechanics.Rules.IsGameValidAndPlayable(game))
            {
                throw new GameRulesBrokenException("The game is in an invalid state!");
            }

            GameMechanics.Persistence.SaveGame(game);

            return game;
        }

        public Game DoMove(Guid gameId, Move move)
        {
            var game = GameMechanics.Persistence.LoadGame(gameId);

            if (!GameMechanics.Rules.IsValidMove(game.GetCurrentState(), move))
            {
                throw new GameRulesBrokenException("That is not a valid move at this point!");
            }

            var newState = GameMechanics.Rules.GetNewStateAfterMove(game.GetCurrentState(), move);

            game.States.Add(newState);

            GameMechanics.Persistence.SaveGame(game);

            return game;
        }

        public Move GetMoveFromParameters(string moveName /*We need some more parameters here*/)
        {
            var move = GameMechanics.Rules.GetMoveByName(moveName);

            // Do something with the move and the parameters here.

            return move;
        }
    }
}
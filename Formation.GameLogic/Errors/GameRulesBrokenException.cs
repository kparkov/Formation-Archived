using System;

namespace Formation.GameLogic.Errors
{
    public class GameRulesBrokenException : Exception
    {
        public GameRulesBrokenException(string message) : base(message) { }
    }
}
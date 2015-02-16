using System;
using Bit.Helpers.Console;
using Formation.GameLogic;
using Formation.GameLogic.Abstract;

namespace Formation.Command
{
    class Program
    {
        private static readonly IGameMechanics GameMechanics = StandardComposition.GetGameMechanics();

        static void Main(string[] args)
        {
            var cm = new ConsoleCommandModule(args);
            cm.Engage("RunGameSimulation");
        }
    }
}

using System.Linq;
using Bit.Helpers.Console;
using Formation.Data.Model;
using Formation.GameLogic;
using Formation.GameLogic.Abstract;

namespace Formation.Command
{
    public class GameConsole : ICommandInterface
    {
        public ConsoleCommandHelpers Csl { get; set; }
        public RunHelpers Run { get; set; }
        public DeploymentHelpers Deployment { get; set; }
        public DatabaseHelpers Database { get; set; }

        private static readonly IGameMechanics GameMechanics = StandardComposition.GetGameMechanics();

        public void RunGameSimulation()
        {
            GameMechanics.Persistence.ResetGameDatabase();

            var game = GameMechanics.TurnTaking.StartNewGame("Luke Skywalker", "Darth Vader");

            OutputGameState(game);

            Csl.Ask("Quit");
        }

        private void OutputGameState(Game game)
        {
            Csl.Header(string.Format("Game state {0}, next to move is {1}", game.States.Count, game.GetActivePlayer().Name));

            Csl.StartTable(18, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4);

            var headers = new[] {"Player"}.Concat(Enumerable.Range(1, 7).Select(x => x.ToString()));

            Csl.TableHead(headers.ToArray());

            var white = new[] {game.White.Name}.Concat(game.GetCurrentState().WhiteCells.Select(x => (x is Die) ? ((Die) x).Value.ToString() : "." ));

            Csl.TableRow(white.ToArray());

            var black = new[] { game.Black.Name }.Concat(game.GetCurrentState().BlackCells.Select(x => (x is Die) ? ((Die) x).Value.ToString() : "." ));

            Csl.TableRow(black.ToArray());

            Csl.Break(2);
        }
    }
}
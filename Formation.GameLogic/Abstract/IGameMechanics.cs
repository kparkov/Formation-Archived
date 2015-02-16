using Formation.GameLogic.Flow;

namespace Formation.GameLogic.Abstract
{
    public interface IGameMechanics
    {
        GameBoardFactory GameBoardFactory { get; }
        Persistence Persistence { get; }
        Rules Rules { get; }
        TurnTaking TurnTaking { get; }
    }
}
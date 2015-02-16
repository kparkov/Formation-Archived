using Formation.GameLogic.Flow;
using Ninject;
using Ninject.Syntax;

namespace Formation.GameLogic.Abstract
{
    public class NinjectGameMechanics : IGameMechanics
    {
        protected IResolutionRoot ResolutionRoot { get; set; }

        public TurnTaking TurnTaking { get { return ResolutionRoot.Get<TurnTaking>(); } }
        public GameBoardFactory GameBoardFactory { get { return ResolutionRoot.Get<GameBoardFactory>(); } }
        public Persistence Persistence { get { return ResolutionRoot.Get<Persistence>(); } }
        public Rules Rules { get { return ResolutionRoot.Get<Rules>(); } }

        public NinjectGameMechanics(IResolutionRoot root)
        {
            ResolutionRoot = root;
        }
    }
}

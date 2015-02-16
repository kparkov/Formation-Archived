using System.Data.Entity;
using Formation.Data.Model;
using Ninject;

namespace Formation.GameLogic.Abstract
{
    public class StandardComposition
    {
        public IGameMechanics GameMechanics { get; set; }
        private IKernel Kernel { get; set; }

        public StandardComposition()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IGameMechanics>().To<NinjectGameMechanics>();
            Kernel.Bind<DbContext>().To<GameStore>();

            GameMechanics = Kernel.Get<IGameMechanics>();
        }

        public static IGameMechanics GetGameMechanics()
        {
            return new StandardComposition().GameMechanics;
        }
    }
}
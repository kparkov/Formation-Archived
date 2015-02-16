namespace Formation.GameLogic.Abstract
{
    public class BaseLogic
    {
        protected IGameMechanics GameMechanics { get; set; }

        public BaseLogic(IGameMechanics gameMechanics)
        {
            GameMechanics = gameMechanics;
        }
    }
}
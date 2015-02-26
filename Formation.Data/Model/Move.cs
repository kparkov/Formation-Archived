namespace Formation.Data.Model
{
    public class Move : Base
    {
        public virtual GameState ApplyMove(GameState currentState)
        {
            return null;
        }
    }

    public class Boost : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Destroy : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Fourify : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Jump : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Match : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Push : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Split : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

    public class Switch : Move
    {
        public override GameState ApplyMove(GameState currentState)
        {
            return base.ApplyMove(currentState);
        }
    }

}
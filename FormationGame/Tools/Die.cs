namespace FormationGame.Tools
{
	public class Die
	{
		// Instansvariable: redskaber, som denne klasse bruger internt
		private RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

		// Properties / Egenskaber: Hvilke data beskriver en terning? Hvilke egenskaber har den?
        public int Value { get; set; }
        public string Color { get; set; }

		// Metoder / Funktioner: Hvad kan en terning? Hvilke handlinger er mulige med en terning?
        public int Roll()
        {
            Value = randomNumberGenerator.GetRandomNumber(1, 6);
            return Value;
        }

		// Constructor: Hvad skal der ske, når en ny terning produceres?
        public Die()
        {
            Roll();
        }
	}
}
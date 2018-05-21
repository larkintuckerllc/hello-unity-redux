public class State
{
	public int A { get; private set; }
    public bool ABDelay { get; private set; }
    public int B { get; private set; }
    public int SpeedCheck { get; private set; }

	public State(int a, bool abDelay, int b,  int speedCheck)
	{
		this.A = a;
        this.ABDelay = abDelay;
        this.B = b;
        this.SpeedCheck = speedCheck;
	}
}
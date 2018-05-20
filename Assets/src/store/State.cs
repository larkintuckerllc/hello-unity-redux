public class State
{
	public int A { get; private set; }
	public int B { get; private set; }
    public bool ABDelay { get; private set; }

	public State(int a, int b, bool abDelay)
	{
		this.A = a;
		this.B = b;
        this.ABDelay = abDelay;
	}
}
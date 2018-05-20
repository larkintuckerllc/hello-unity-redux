public class State
{
	readonly int a;
	readonly int b;
    readonly bool abDelay;

	public State(int a, int b, bool abDelay)
	{
		this.a = a;
		this.b = b;
        this.abDelay = abDelay;
	}

	public int A
	{
		get { return a; }
	}

	public int B
	{
		get { return b; }
	}

    public bool ABDelay
    {
        get { return abDelay;  }
    }
}
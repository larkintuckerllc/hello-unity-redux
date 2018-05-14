public class State
{
	readonly int a;
	readonly int b;

	public State(int a, int b)
	{
		this.a = a;
		this.b = b;
	}

	public int A
	{
		get { return a; }
	}

	public int B
	{
		get { return b; }
	}
}
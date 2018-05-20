public class A : Singleton<A>
{
    protected A() { }

    public Action IncrementA()
    {
        return new Action(Store.Actions.INCREMENT_A);
    }

    public Action DecrementA()
	{
		return new Action(Store.Actions.DECREMENT_A);
	}

    public Action ZeroA()
    {
        return new Action(Store.Actions.ZERO_A);
    }

    public static int InitialState = 0;

	public static int Reducer(int state, Action action)
	{
		switch (action.Type)
		{
			case Store.Actions.INCREMENT_A:
				return state + 1;
			case Store.Actions.DECREMENT_A:
				return state - 1;
            case Store.Actions.ZERO_A:
                return 0;
			default:
				return state;
		}
	}

	public static int GetA(State state)
	{
		return state.A;
	}
}

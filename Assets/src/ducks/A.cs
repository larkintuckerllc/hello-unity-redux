public static class A
{
    public static Action IncrementA()
	{
		return new Action(Store.Actions.INCREMENT_A);
	}

	public static Action DecrementA()
	{
		return new Action(Store.Actions.DECREMENT_A);
	}
    
	public static int InitialState()
	{
		return 0;
	}

	public static int Reducer(int state, Action action)
	{
		switch (action.Type)
		{
			case Store.Actions.INCREMENT_A:
				return state + 1;
			case Store.Actions.DECREMENT_A:
				return state - 1;
			default:
				return state;
		}
	}

	public static int getA(State state)
	{
		return state.A;
	}
}

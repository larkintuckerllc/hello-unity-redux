public class B : Singleton<B>
{
    protected B() { }

	public Action IncrementB()
	{
		return new Action(Store.Actions.INCREMENT_B);
	}

	public Action DecrementB()
	{
		return new Action(Store.Actions.DECREMENT_B);
	}

    public Action ZeroB()
    {
        return new Action(Store.Actions.ZERO_B);
    }

    public static int InitialState = 0;

	public static int Reducer(int state, Action action)
	{
		switch (action.Type)
		{
			case Store.Actions.INCREMENT_B:
				return state + 1;
			case Store.Actions.DECREMENT_B:
				return state - 1;
            case Store.Actions.ZERO_B:
                return 0;
			default:
				return state;
		}
	}
	public static int GetB(State state)
	{
		return state.B;
	}
}

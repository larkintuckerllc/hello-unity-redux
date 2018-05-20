public class A : Singleton<A>
{
    public static int InitialState = 0;

	public static int Reducer(int state, Action action)
	{
		switch (action.Type)
		{
			case Provider.Actions.INCREMENT_A:
				return state + 1;
			case Provider.Actions.DECREMENT_A:
				return state - 1;
            case Provider.Actions.ZERO_A:
                return 0;
			default:
				return state;
		}
	}

	public static int GetA(State state)
	{
		return state.A;
	}

    protected A() { }

    public Action IncrementA()
    {
        return new Action(Provider.Actions.INCREMENT_A);
    }

    public Action DecrementA()
    {
        return new Action(Provider.Actions.DECREMENT_A);
    }

    public Action ZeroA()
    {
        return new Action(Provider.Actions.ZERO_A);
    }

    public Action IncrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch(A.Instance.IncrementA());
            dispatch(B.Instance.IncrementB());
        });
    }

    public Action DecrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch(A.Instance.DecrementA());
            dispatch(B.Instance.DecrementB());
        });
    }
}

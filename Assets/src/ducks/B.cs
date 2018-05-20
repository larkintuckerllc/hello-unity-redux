public class B : Singleton<B>
{
    public static int InitialState = 0;

    public static int Reducer(int state, Action action)
    {
        switch (action.Type)
        {
            case Provider.Actions.INCREMENT_B:
                return state + 1;
            case Provider.Actions.DECREMENT_B:
                return state - 1;
            case Provider.Actions.ZERO_B:
                return 0;
            default:
                return state;
        }
    }

    public static int GetB(State state)
    {
        return state.B;
    }

    protected B() { }

	public Action IncrementB()
	{
		return new Action(Provider.Actions.INCREMENT_B);
	}

	public Action DecrementB()
	{
		return new Action(Provider.Actions.DECREMENT_B);
	}

    public Action ZeroB()
    {
        return new Action(Provider.Actions.ZERO_B);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class B
{
	public static Action IncrementB()
    {
		return new Action(Store.Actions.INCREMENT_B);
    }

    public static Action DecrementB()
    {
        return new Action(Store.Actions.DECREMENT_B);
    }

	public static int InitialState()
    {
        return 0;
    }

    public static int Reducer(int state, Action action)
    {
        switch (action.Type)
        {
            case Store.Actions.INCREMENT_B:
                return state + 1;
            case Store.Actions.DECREMENT_B:
                return state - 1;
            default:
                return state;
        }
    }
	public static int getB(State state)
    {
        return state.B;
    }
}

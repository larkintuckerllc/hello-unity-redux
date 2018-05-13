using System;
using UniRx;

public static class Store
{
	public enum Actions
	{ 
		__INIT, 
		INCREMENT_A,
		DECREMENT_A,
		INCREMENT_B,
		DECREMENT_B 
	}

    public static State Reducer(State state, Action action)
    {
		bool hasChanged = false;
        int nextStateA = A.Reducer(state.A, action);
		if (nextStateA != state.A) {
			hasChanged = true;
		}
        int nextStateB = B.Reducer(state.B, action);
		if (nextStateB != state.B)
        {
            hasChanged = true;
        }
		return hasChanged ? new State(nextStateA, nextStateB) : state;
    }

	static readonly Func<State, Action, State> reducer = Reducer;

	public readonly static ISubject<Action> storeDispatch = new BehaviorSubject<Action>(new Action(Actions.__INIT));

	public readonly static IObservable<State> storeState = storeDispatch.Scan(new State(
         A.InitialState(),
         B.InitialState()
    ), reducer);
}
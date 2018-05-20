using System;
using UniRx;

public static class StoreBak
{
    /*
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
		if (nextStateA != state.A)
		{
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

	static readonly State initialState = new State(
	  A.InitialState(),
	  B.InitialState()
	);

	public static readonly ISubject<Action> storeDispatch = new Subject<Action>();

	public static readonly BehaviorSubject<State> storeState = new BehaviorSubject<State>(initialState);

	static readonly System.IDisposable storePrivate = storeDispatch.Scan(initialState, reducer).Subscribe(storeState);
    */
}
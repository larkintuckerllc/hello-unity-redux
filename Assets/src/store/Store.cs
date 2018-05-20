using System;
using UnityEngine;
using UniRx;

public class Store : Singleton<Store>
{
    protected Store() { }

    public enum Actions
    {
        __INIT,
        THUNK,
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

    public static Action Logger(Action action)
    {
        Debug.Log(action.Type);
        return action;
    }

    public static Boolean FilterThunk(Action action)
    {
        return action.Type != Actions.THUNK;
    }

    public ISubject<Action> storeDispatch = new Subject<Action>();

    public BehaviorSubject<State> storeState;

    public void Initialize()
    {
        State initialState = new State(
            A.InitialState(),
            B.InitialState()
        );
        storeState = new BehaviorSubject<State>(initialState);
        storeDispatch
            .Where<Action>(FilterThunk)
            .Select(Logger)
            .Scan(initialState, Reducer)
            .Subscribe(storeState);
        storeDispatch.OnNext(new Action(Store.Actions.__INIT));
    }
}

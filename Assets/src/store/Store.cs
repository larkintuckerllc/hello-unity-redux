using System;
using UnityEngine;
using UniRx;

public static class Store
{
    static BehaviorSubject<State> storeState;

    public enum Actions
    {
        __INIT,
        DELAY_ZERO_AB_START,
        DELAY_ZERO_AB_END,
        INCREMENT_A,
        INCREMENT_B,
        DECREMENT_A,
        DECREMENT_B,
        ZERO_A,
        ZERO_B,
        THUNK
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
        bool nextABDelay = ABDelay.Reducer(state.ABDelay, action);
        if (nextABDelay != state.ABDelay)
        {
            hasChanged = true;
        }
        return hasChanged ? new State(nextStateA, nextStateB, nextABDelay) : state;
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

    public readonly static ISubject<Action> storeDispatch = new Subject<Action>();

    public static BehaviorSubject<State> StoreState
    {
        get { return storeState; }
    }

    public static void Initialize()
    {
        State initialState = new State(
            A.InitialState,
            B.InitialState,
            ABDelay.InitialState
        );
        storeState = new BehaviorSubject<State>(initialState);
        storeDispatch
            .Where<Action>(FilterThunk)
            .Select(Logger)
            .Scan(initialState, Reducer)
            // TODO: NEED TO EXTRACT STATE HERE
            .Subscribe(storeState);
        storeDispatch.OnNext(new Action(Store.Actions.__INIT));
    }
}

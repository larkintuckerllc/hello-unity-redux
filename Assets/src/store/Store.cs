using System;
using UnityEngine;
using UniRx;

public static class Store
{
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

    public static ISubject<Action> Dispatch { get; private set; }

    public static BehaviorSubject<State> StoreState { get; private set; }

    public static void Initialize()
    {
        Dispatch = new Subject<Action>();
        State initialState = new State(
            A.InitialState,
            B.InitialState,
            ABDelay.InitialState
        );
        StoreState = new BehaviorSubject<State>(initialState);
        Dispatch
            .Where<Action>(FilterThunk)
            .Select(Logger)
            .Scan(initialState, Reducer)
            // TODO: NEED TO EXTRACT STATE HERE
            .Subscribe(StoreState);
        Dispatch.OnNext(new Action(Store.Actions.__INIT));
    }
}

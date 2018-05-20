using System;
using UnityEngine;
using UniRx;

public static class Provider
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

    public static State ExtractState(State state)
    {
        return state;
    }

    static ISubject<Action> StoreDispatch;

    public static void Dispatch(Action action)
    {
        StoreDispatch.OnNext(action);
    }

    public static BehaviorSubject<State> Store { get; private set; }

    public static void Initialize()
    {
        StoreDispatch = new Subject<Action>();
        State initialState = new State(
            A.InitialState,
            B.InitialState,
            ABDelay.InitialState
        );
        Store = new BehaviorSubject<State>(initialState);
        StoreDispatch
            .Where<Action>(FilterThunk)
            .Select(Logger)
            .Scan(initialState, Reducer)
            .Select(ExtractState)
            .Subscribe(Store);
        Dispatch(new Action(Actions.__INIT));
    }
}

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
        SET_SPEED_CHECK,
        THUNK,
        ZERO_A,
        ZERO_B
    }

    private static State state;

    public static State GetState()
    {
        return state;
    }

    public static State Reducer(State state, Action action)
    {
        bool hasChanged = false;
        int nextStateA = A.Reducer(state.A, action);
        if (nextStateA != state.A)
        {
            hasChanged = true;
        }
        bool nextABDelay = ABDelay.Reducer(state.ABDelay, action);
        if (nextABDelay != state.ABDelay)
        {
            hasChanged = true;
        }
        int nextStateB = B.Reducer(state.B, action);
        if (nextStateB != state.B)
        {
            hasChanged = true;
        }
        int nextSpeedCheck = SpeedCheck.Reducer(state.SpeedCheck, action);
        if (nextSpeedCheck != state.SpeedCheck)
        {
            hasChanged = true;
        }
        return hasChanged ? new State(nextStateA, nextABDelay, nextStateB, nextSpeedCheck) : state;
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
        Provider.state = state;
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
            ABDelay.InitialState,
            B.InitialState,
            SpeedCheck.InitialState
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

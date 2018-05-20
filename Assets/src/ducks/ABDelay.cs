using System;
using System.Collections;
using UnityEngine;
using UniRx;

public class ABDelay : Singleton<ABDelay>
{
    public static bool InitialState = false;

    public static bool Reducer(bool state, Action action)
    {
        switch (action.Type)
        {
            case Provider.Actions.DELAY_ZERO_AB_START:
                return true;
            case Provider.Actions.DELAY_ZERO_AB_END:
                return false;
            default:
                return state;
        }
    }

    public static bool GetABDelay(State state)
    {
        return state.ABDelay;
    }

    protected ABDelay() { }

    IEnumerator DelayZeroABEnumerator(Action<Action> dispatch)
    {
        // REPLACE WITH STATE
        // BehaviorSubject<State> state = getState();
        dispatch(DelayZeroABStart());
        yield return new WaitForSeconds(3f);
        dispatch(A.Instance.ZeroA());
        dispatch(B.Instance.ZeroB());
        dispatch(DelayZeroABEnd());
    }

    public Action DelayZeroAB()
    {
        return new Action(dispatch =>
        {
            IEnumerator enumerator = DelayZeroABEnumerator(dispatch);
            StartCoroutine(enumerator);
        });
    }

    public Action DelayZeroABStart()
    {
        return new Action(Provider.Actions.DELAY_ZERO_AB_START);
    }

    public Action DelayZeroABEnd()
    {
        return new Action(Provider.Actions.DELAY_ZERO_AB_END);
    }
}

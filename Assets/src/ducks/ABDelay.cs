using System;
using System.Collections;
using UnityEngine;
using UniRx;

public class ABDelay : Singleton<ABDelay>
{
    protected ABDelay() { }

    IEnumerator DelayZeroABEnumerator(ISubject<Action> dispatch)
    {
        // REPLACE WITH STATE
        // BehaviorSubject<State> state = getState();
        dispatch.OnNext(DelayZeroABStart());
        yield return new WaitForSeconds(3f);
        dispatch.OnNext(A.Instance.ZeroA());
        dispatch.OnNext(B.Instance.ZeroB());
        dispatch.OnNext(DelayZeroABEnd());
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
        return new Action(Store.Actions.DELAY_ZERO_AB_START);
    }

    public Action DelayZeroABEnd()
    {
        return new Action(Store.Actions.DELAY_ZERO_AB_END);
    }

    public static bool InitialState = false;

    public static bool Reducer(bool state, Action action)
    {
        switch (action.Type)
        {
            case Store.Actions.DELAY_ZERO_AB_START:
                return true;
            case Store.Actions.DELAY_ZERO_AB_END:
                return false;
            default:
                return state;
        }
    }

    public static bool GetABDelay(State state)
    {
        return state.ABDelay;
    }
}

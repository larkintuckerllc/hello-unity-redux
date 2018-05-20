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

    IEnumerator DelayZeroABEnumerator(Action<Action> dispatch, Func<State> getState)
    {
        State state = getState();
        bool abDelay = GetABDelay(state);
        if (abDelay)
        {
            yield break;
        }
        dispatch(DelayZeroABStart());
        yield return new WaitForSeconds(5f);
        dispatch(A.Instance.ZeroA());
        dispatch(B.Instance.ZeroB());
        dispatch(DelayZeroABEnd());
    }

    public Action DelayZeroAB()
    {
        return new Action((dispatch, getState) =>
        {
            IEnumerator enumerator = DelayZeroABEnumerator(dispatch, getState);
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

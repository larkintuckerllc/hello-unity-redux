using UnityEngine;

public class SpeedCheck : Singleton<SpeedCheck>
{
    public static int InitialState = 0;

    public static int Reducer(int state, Action action)
    {
        switch (action.Type)
        {
            case Provider.Actions.SET_SPEED_CHECK:
                return action.PayloadInt;
            default:
                return state;
        }
    }

    public static int GetSpeedCheck(State state)
    {
        return state.SpeedCheck;
    }

    protected SpeedCheck() { }

    public Action SetSpeedCheck(int speed)
    {
        return new Action(Provider.Actions.SET_SPEED_CHECK, speed);
    }
}

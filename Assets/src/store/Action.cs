using System;
using UnityEngine;

public class Action
{
    public Provider.Actions Type { get; private set; }

    public int PayloadInt { get; private set; }

    public Action(Provider.Actions type)
	{
		this.Type = type;
	}

    public Action(Provider.Actions type, int payload)
    {
        this.Type = type;
        this.PayloadInt = payload;
    }

    public Action(Action<Action<Action>> function)
    {
        this.Type = Provider.Actions.THUNK;
        function(Provider.Dispatch);
    }

    public Action(Action<Action<Action>, Func<State>> function)
    {
        this.Type = Provider.Actions.THUNK;
        function(Provider.Dispatch, Provider.GetState);
    }

    }

using System;
using UniRx;

public class Action
{
    public Provider.Actions Type { get; private set; }

    public Action(Provider.Actions type)
	{
		this.Type = type;
	}

    public Action(Action<Action<Action>> function)
    {
        this.Type = Provider.Actions.THUNK;
        function(Provider.Dispatch);
    }
}

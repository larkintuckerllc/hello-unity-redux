using System;
using UniRx;

public class Action
{
    public Store.Actions Type { get; private set; }

    public Action(Store.Actions type)
	{
		this.Type = type;
	}

    public Action(Action<ISubject<Action>> function)
    {
        this.Type = Store.Actions.THUNK;
        function(Store.Dispatch);
    }
}

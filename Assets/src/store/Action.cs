using System;
using UniRx;

public class Action
{
	readonly Store.Actions type;
    readonly Action<ISubject<Action>> function;

	public Action(Store.Actions type)
	{
		this.type = type;
	}

    public Action(Action<ISubject<Action>> function)
    {
        this.type = Store.Actions.THUNK;
        function(Store.Instance.storeDispatch);
    }

	public Store.Actions Type
	{
		get { return type; }
	}
}

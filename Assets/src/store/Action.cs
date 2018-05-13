public class Action
{
	readonly Store.Actions type;

	public Action(Store.Actions type)
	{
		this.type = type;
	}

	public Store.Actions Type
	{
		get { return type; }
	}
}
      
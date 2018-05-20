
public class AB
{
    public static Action IncrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch.OnNext(A.IncrementA());
            dispatch.OnNext(B.IncrementB());
        });
    }

    public static Action DecrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch.OnNext(A.DecrementA());
            dispatch.OnNext(B.DecrementB());
        });
    }
}

public class AB : Singleton<AB>
{
    protected AB() { }

    public Action IncrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch.OnNext(A.Instance.IncrementA());
            dispatch.OnNext(B.Instance.IncrementB());
        });
    }

    public Action DecrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch.OnNext(A.Instance.DecrementA());
            dispatch.OnNext(B.Instance.DecrementB());
        });
    }
}

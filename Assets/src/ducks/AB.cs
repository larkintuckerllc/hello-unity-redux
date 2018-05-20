public class AB : Singleton<AB>
{
    protected AB() { }

    public Action IncrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch(A.Instance.IncrementA());
            dispatch(B.Instance.IncrementB());
        });
    }

    public Action DecrementAB()
    {
        return new Action(dispatch =>
        {
            dispatch(A.Instance.DecrementA());
            dispatch(B.Instance.DecrementB());
        });
    }
}

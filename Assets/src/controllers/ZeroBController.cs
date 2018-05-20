using UnityEngine;

public class ZeroBController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Instance.storeDispatch.OnNext(B.Instance.ZeroB());
    }
}
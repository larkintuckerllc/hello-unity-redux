using UnityEngine;

public class ZeroBController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(B.Instance.ZeroB());
    }
}
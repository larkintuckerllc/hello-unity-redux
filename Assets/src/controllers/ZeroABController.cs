using UnityEngine;

public class ZeroABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Instance.storeDispatch.OnNext(ABDelay.Instance.DelayZeroAB());
    }
}
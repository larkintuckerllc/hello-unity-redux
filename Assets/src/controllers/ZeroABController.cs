using UnityEngine;

public class ZeroABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(ABDelay.Instance.DelayZeroAB());
    }
}
using UnityEngine;

public class ZeroABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Dispatch.OnNext(ABDelay.Instance.DelayZeroAB());
    }
}
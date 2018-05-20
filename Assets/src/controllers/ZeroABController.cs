using UnityEngine;

public class ZeroABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Provider.Dispatch(ABDelay.Instance.DelayZeroAB());
    }
}
using UnityEngine;

public class IncrementBController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(B.IncrementB());
    }
}
